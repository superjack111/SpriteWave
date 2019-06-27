﻿/*
 * Created by SharpDevelop.
 * User: 101111482
 * Date: 28/04/2019
 * Time: 9:48 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;

namespace SpriteWave
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private IContainer components = null;

		private PictureBox inputBox;
		private VScrollBar inputScroll;
		private ContextMenuStrip inputMenu;
		private Panel inputPanel;
		private Label inputOffsetLabel;
		private TextBox inputOffset;
		private Label inputSizeLabel;
		private PictureBox inputSample;
		private Button inputSend;

		private PictureBox spriteBox;
		private HScrollBar spriteScrollX;
		private VScrollBar spriteScrollY;
		private ContextMenuStrip spriteMenu;

		private MenuStrip menuStrip1;
		private ToolStripMenuItem fileToolStripMenuItem;
		private ToolStripMenuItem openBinaryToolStripMenuItem;
		private ToolStripMenuItem openNESFileStripMenuItem;
		private ToolStripMenuItem openSNESFileStripMenuItem;
		private ToolStripSeparator toolStripSeparator1;
		private ToolStripMenuItem closeToolStripMenuItem;
		private ToolStripMenuItem quitToolStripMenuItem;
		private OpenFileDialog openFileDialog1;
		private ToolStripMenuItem copyTileToolStripMenuItem;

		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.inputBox = new System.Windows.Forms.PictureBox();
			this.inputScroll = new System.Windows.Forms.VScrollBar();
			this.inputPanel = new System.Windows.Forms.Panel();
			this.inputSend = new System.Windows.Forms.Button();
			this.inputSample = new System.Windows.Forms.PictureBox();
			this.inputSizeLabel = new System.Windows.Forms.Label();
			this.inputOffsetLabel = new System.Windows.Forms.Label();
			this.inputOffset = new System.Windows.Forms.TextBox();
			this.spriteBox = new System.Windows.Forms.PictureBox();
			this.spriteScrollX = new System.Windows.Forms.HScrollBar();
			this.spriteScrollY = new System.Windows.Forms.VScrollBar();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openBinaryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openNESFileStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openSNESFileStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.inputMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.copyTileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.spriteMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			((System.ComponentModel.ISupportInitialize)(this.inputBox)).BeginInit();
			this.inputPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.inputSample)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.spriteBox)).BeginInit();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// inputBox
			// 
			this.inputBox.BackColor = System.Drawing.SystemColors.ControlDark;
			this.inputBox.Location = new System.Drawing.Point(0, 24);
			this.inputBox.Name = "inputBox";
			this.inputBox.Size = new System.Drawing.Size(331, 496);
			this.inputBox.TabIndex = 0;
			this.inputBox.TabStop = false;
			// 
			// inputScroll
			// 
			this.inputScroll.Location = new System.Drawing.Point(331, 24);
			this.inputScroll.Name = "inputScroll";
			this.inputScroll.Size = new System.Drawing.Size(17, 496);
			this.inputScroll.TabIndex = 3;
			this.inputScroll.Visible = false;
			// 
			// inputPanel
			// 
			this.inputPanel.Controls.Add(this.inputSend);
			this.inputPanel.Controls.Add(this.inputSample);
			this.inputPanel.Controls.Add(this.inputSizeLabel);
			this.inputPanel.Controls.Add(this.inputOffsetLabel);
			this.inputPanel.Controls.Add(this.inputOffset);
			this.inputPanel.Location = new System.Drawing.Point(0, 520);
			this.inputPanel.Name = "inputPanel";
			this.inputPanel.Size = new System.Drawing.Size(370, 58);
			this.inputPanel.TabIndex = 4;
			// 
			// inputSend
			// 
			this.inputSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.inputSend.Location = new System.Drawing.Point(200, 12);
			this.inputSend.Name = "inputSend";
			this.inputSend.Size = new System.Drawing.Size(90, 24);
			this.inputSend.TabIndex = 8;
			this.inputSend.Text = "Send To Sprite";
			this.inputSend.UseVisualStyleBackColor = true;
			this.inputSend.Visible = false;
			// 
			// inputSample
			// 
			this.inputSample.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.inputSample.BackColor = System.Drawing.SystemColors.ControlLight;
			this.inputSample.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.inputSample.Location = new System.Drawing.Point(300, 4);
			this.inputSample.Name = "inputSample";
			this.inputSample.Size = new System.Drawing.Size(40, 40);
			this.inputSample.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.inputSample.TabIndex = 7;
			this.inputSample.TabStop = false;
			this.inputSample.Visible = false;
			// 
			// inputSizeLabel
			// 
			this.inputSizeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.inputSizeLabel.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.inputSizeLabel.Location = new System.Drawing.Point(120, 18);
			this.inputSizeLabel.Name = "inputSizeLabel";
			this.inputSizeLabel.Size = new System.Drawing.Size(58, 15);
			this.inputSizeLabel.TabIndex = 6;
			this.inputSizeLabel.Text = "/";
			this.inputSizeLabel.Visible = false;
			// 
			// inputOffsetLabel
			// 
			this.inputOffsetLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.inputOffsetLabel.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.inputOffsetLabel.Location = new System.Drawing.Point(10, 18);
			this.inputOffsetLabel.Name = "inputOffsetLabel";
			this.inputOffsetLabel.Size = new System.Drawing.Size(48, 15);
			this.inputOffsetLabel.TabIndex = 0;
			this.inputOffsetLabel.Text = "Offset: 0x";
			this.inputOffsetLabel.Visible = false;
			// 
			// inputOffset
			// 
			this.inputOffset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.inputOffset.Enabled = false;
			this.inputOffset.Location = new System.Drawing.Point(58, 15);
			this.inputOffset.Name = "inputOffset";
			this.inputOffset.Size = new System.Drawing.Size(60, 20);
			this.inputOffset.TabIndex = 5;
			this.inputOffset.Text = "0";
			this.inputOffset.Visible = false;
			// 
			// spriteBox
			// 
			this.spriteBox.BackColor = System.Drawing.SystemColors.ControlDark;
			this.spriteBox.Location = new System.Drawing.Point(352, 24);
			this.spriteBox.Name = "spriteBox";
			this.spriteBox.Size = new System.Drawing.Size(331, 269);
			this.spriteBox.TabIndex = 0;
			this.spriteBox.TabStop = false;
			// 
			// spriteScrollX
			// 
			this.spriteScrollX.Location = new System.Drawing.Point(352, 293);
			this.spriteScrollX.Name = "spriteScrollX";
			this.spriteScrollX.Size = new System.Drawing.Size(331, 17);
			this.spriteScrollX.TabIndex = 3;
			this.spriteScrollX.Visible = false;
			// 
			// spriteScrollY
			// 
			this.spriteScrollY.Location = new System.Drawing.Point(683, 24);
			this.spriteScrollY.Name = "spriteScrollY";
			this.spriteScrollY.Size = new System.Drawing.Size(17, 269);
			this.spriteScrollY.TabIndex = 4;
			this.spriteScrollY.Visible = false;
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.fileToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(704, 24);
			this.menuStrip1.TabIndex = 4;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.openBinaryToolStripMenuItem,
			this.openNESFileStripMenuItem,
			this.openSNESFileStripMenuItem,
			this.toolStripSeparator1,
			this.closeToolStripMenuItem,
			this.quitToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "File";
			// 
			// openBinaryToolStripMenuItem
			// 
			this.openBinaryToolStripMenuItem.Name = "openBinaryToolStripMenuItem";
			this.openBinaryToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+O";
			this.openBinaryToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
			this.openBinaryToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
			this.openBinaryToolStripMenuItem.Text = "Open Binary";
			this.openBinaryToolStripMenuItem.Click += new System.EventHandler(this.openBinary);
			// 
			// toolStripMenuItem1
			// 
			this.openNESFileStripMenuItem.Name = "openNESFileStripMenuItem";
			this.openNESFileStripMenuItem.Size = new System.Drawing.Size(209, 22);
			this.openNESFileStripMenuItem.Text = "Open NES File";
			this.openNESFileStripMenuItem.Click += new System.EventHandler(this.openNES);
			// 
			// toolStripMenuItem2
			// 
			this.openSNESFileStripMenuItem.Name = "openSNESFileStripMenuItem";
			this.openSNESFileStripMenuItem.Size = new System.Drawing.Size(209, 22);
			this.openSNESFileStripMenuItem.Text = "Open SNES File";
			this.openSNESFileStripMenuItem.Click += new System.EventHandler(this.openSNES);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(206, 6);
			// 
			// closeToolStripMenuItem
			// 
			this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
			this.closeToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+W";
			this.closeToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
			this.closeToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
			this.closeToolStripMenuItem.Text = "Close Workspace";
			this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeWorkspace);
			// 
			// quitToolStripMenuItem
			// 
			this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
			this.quitToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
			this.quitToolStripMenuItem.Text = "Quit";
			this.quitToolStripMenuItem.Click += new System.EventHandler(this.quit);
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.Title = "Open tiles file";
			this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1FileOk);
			// 
			// inputMenu
			// 
			this.inputMenu.Name = "inputMenu";
			this.inputMenu.Size = new System.Drawing.Size(61, 4);
			// 
			// copyTileToolStripMenuItem
			// 
			this.copyTileToolStripMenuItem.Name = "copyTileToolStripMenuItem";
			this.copyTileToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
			// 
			// spriteMenu
			// 
			this.spriteMenu.Name = "spriteMenu";
			this.spriteMenu.Size = new System.Drawing.Size(61, 4);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(704, 601);
			this.Controls.Add(this.inputBox);
			this.Controls.Add(this.inputScroll);
			this.Controls.Add(this.inputPanel);
			this.Controls.Add(this.spriteBox);
			this.Controls.Add(this.spriteScrollX);
			this.Controls.Add(this.spriteScrollY);
			this.Controls.Add(this.menuStrip1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.MinimumSize = new System.Drawing.Size(200, 400);
			this.Name = "MainForm";
			this.Text = "SpriteWave";
			((System.ComponentModel.ISupportInitialize)(this.inputBox)).EndInit();
			this.inputPanel.ResumeLayout(false);
			this.inputPanel.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.inputSample)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.spriteBox)).EndInit();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
	}
}
