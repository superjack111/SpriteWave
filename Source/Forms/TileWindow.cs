﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace SpriteWave
{
	public abstract class TileWindow
	{
		protected Collage _cl;

		//bool active = false;

		//public bool IsActive { get { return _cl != null && active; } }

		//public abstract Position VisibleSelection { get; }

		public abstract SizeF TileDimensions { get; }
		public abstract Rectangle VisibleCollageBounds { get; }

		protected Brush _defHl, _cursorHl;
		protected Brush _selHl;
		protected Position _selPos;
		protected bool _isSel = false;

		protected TabPage _controlsTab;
		public abstract TabPage ControlsTab { get; }

		public abstract HScrollBar ScrollX { set; }

		protected VScrollBar _scrollY;
		public abstract VScrollBar ScrollY { set; }

		protected PictureBox _window;
		public abstract PictureBox Canvas { set; }
		public Point CanvasPos { get { return _window.Location; } }
		public Size CanvasSize { get { return _window.Size; } }

		protected ContextMenuStrip _menu;
		public abstract ContextMenuStrip Menu { set; }

		//public virtual string Prompt { set { return; } }

		protected Rectangle _bounds;
		protected Pen _gridPen;

		public bool Selected
		{
			get {
				return _isSel;
			}
			set {
				_isSel = value;
				ResetSample();
			}
		}

		public Position Position
		{
			get {
				Selected = true;
				return _selPos;
			}
			set {
				_selPos = value;
				Selected = true;
			}
		}

		protected Selection _cursor;
		public Selection Cursor
		{
			set {
				_cursor = value;
				if (_cursor == null)
					_selHl = _defHl;
				else
				{
					_selHl = _cursorHl;
					Selected = true;
				}
			}
			get {
				return _cursor;
			}
		}

		public Selection CurrentSelection()
		{
			if (!_isSel)
				return null;

			return _cursor ?? new Selection(this.PieceAt(_selPos), this, _selPos);
		}

		public void AdoptCursor()
		{
			if (_cursor != null)
				this.Position = _cursor.Location;
		}

		public virtual void ResizeCollage(Edge msg) {}
		public virtual void ReceiveTile(Tile t) {}
		public virtual void ReceiveTile(Tile t, Position loc) {}
		public virtual void DeleteSelection() {}

		public abstract void Scroll(float dx, float dy);
		public abstract void ScrollTo(float x, float y);

		public abstract void ResetScroll();
		public abstract void UpdateBars();
		
		public abstract Position GetPosition(int x, int y, bool allowOob = false);
		public abstract RectangleF PieceHitbox(Position p);

		public abstract void AdjustWindow(int width = 0, int height = 0);

		public abstract void DrawGrid(Graphics g);

		public abstract void AdjustControlsTab();

		protected TileWindow()
		{
			_selPos = new Position(0, 0);
			_defHl = new SolidBrush(Color.FromArgb(96, 0, 64, 255));
			_cursorHl = new SolidBrush(Color.FromArgb(96, 0, 255, 64));
			_selHl = _defHl;
		}

		public virtual void Activate()
		{
			_scrollY.Visible = true;
		}

		public virtual void Close()
		{
			_scrollY.Visible = false;
			_cl = null;
			DeleteFrame();
		}

		public virtual void Render()
		{
			_cl.Render();
		}

		public virtual IPiece PieceAt(Position loc)
		{
			if (_cl == null)
				return null;

			return _cl.TileAt(loc);
		}

		public void DeleteFrame()
		{
			if (_window.Image != null)
			{
				_window.Image.Dispose();
				_window.Image = null;
			}
		}

		public virtual void ShowMenu(int x, int y)
		{
			if ( _window != null && _cl != null)
				_menu.Show(_window, new Point(x, y));
		}

		public virtual void MoveSelection(int dCol, int dRow)
		{
			if (_cl == null)
				return;
			
			int nCols = _cl.Columns;
			int idx = (_selPos.row + dRow) * nCols + _selPos.col + dCol;

			if (idx < 0)
				idx = 0;
			else if (idx >= _cl.nTiles)
				idx = _cl.nTiles - 1;

			this.Position = new Position(idx % nCols, idx / nCols);
		}

		public Bitmap TileBitmap(Tile t)
		{
			if (t == null || _cl == null)
				return null;

			return _cl.RenderTile(t);
		}
		
		public virtual void ResetSample() {}

		public virtual EdgeKind EdgeOf(Position p) { return EdgeKind.None; }
		public virtual PointF[] ShapeEdge(Edge edge) { return null; }

		public void ResetGridPen()
		{
			uint marginClr = Utils.InvertRGB(_cl.MeanColour);
			_gridPen = new Pen(Utils.FromRGB(marginClr), 1.0f);
		}

		public virtual void DrawCanvas(Graphics g)
		{
			Rectangle clBounds = VisibleCollageBounds;
			if (clBounds.Width <= 0 || clBounds.Height <= 0)
				return;

			// Select the subset of the window's collage to render
			using (Bitmap canvas = _cl.Bitmap.Clone(clBounds, _cl.Bitmap.PixelFormat))
			{
				// Draw the visible section of the collage. This method automatically resizes our provided bitmap before drawing it.
				g.DrawImage(canvas, 0, 0, _window.Width, _window.Height);
			}
		}

		public void DrawSelection(Graphics g)
		{
			if (!_isSel || _selHl == null)
				return;

			Position loc;
			IPiece obj;
			if (_cursor != null)
			{
				loc = _cursor.Location;
				obj = _cursor.Piece;
			}
			else
			{
				loc = _selPos;
				obj = PieceAt(_selPos);
			}

			if (obj != null && obj.EdgeKind != EdgeKind.None)
				g.FillPolygon(_selHl, ShapeEdge(obj as Edge));
			else
				g.FillRectangle(_selHl, PieceHitbox(loc));
		}

		public virtual void DrawEdges(Graphics g) {}

		public virtual void Draw()
		{
			if (_cl == null || _window == null)
				return;

			int wndW = _window.Width;
			int wndH = _window.Height;
			if (wndW <= 0 || wndH <= 0)
				return;

			// Make sure the window's collage has something for us to draw
			if (_cl.Bitmap == null)
				Render();

			DeleteFrame();
			_window.Image = new Bitmap(wndW, wndH);

			using (var g = Graphics.FromImage(_window.Image))
			{
				/*
					Here, we first disable pixel interpolation (blurring). This is because the section of the collage we just selected
					is almost certainly going to be smaller or larger than the space we want to render it to.
					The aim is to retain the blocky, "8-bit" look, while maximising the available space.
				*/
				g.ToggleSmoothing(false);

				// Draw the tiles
				DrawCanvas(g);

				// Highlight the current tile, if one is currently selected
				DrawSelection(g);

				// Draw some borders to indicate that the window's collage can be resized
				// Only implemented in SpriteWindow
				DrawEdges(g);

				// In order to more easily discern between tiles on the screen, we draw margins around each tile.
				if (_gridPen == null)
					ResetGridPen();

				DrawGrid(g);
			}
		}

		protected void adjustWindowSize(object sender, EventArgs e)
		{
			AdjustWindow(_window.Width, _window.Height);
			//Draw();
		}

		public virtual void InitialiseControlsTab()
		{
			_controlsTab = new TabPage();
			_controlsTab.Location = new System.Drawing.Point(4, 22);
			_controlsTab.Name = "controlsTab";
			_controlsTab.Padding = new System.Windows.Forms.Padding(3);
			_controlsTab.Size = new System.Drawing.Size(316, 203);
			_controlsTab.TabIndex = 1;
			_controlsTab.Text = "Controls";
			_controlsTab.UseVisualStyleBackColor = true;
		}
	}
}
