namespace litera
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            tabControl1 = new TabControl();
            tabPage2 = new TabPage();
            menuStrip1 = new MenuStrip();
            toolStripMenuItem1 = new ToolStripMenuItem();
            toolStripMenuItem2 = new ToolStripMenuItem();
            toolStripMenuItem3 = new ToolStripMenuItem();
            toolStripSeparator6 = new ToolStripSeparator();
            toolStripMenuItem4 = new ToolStripMenuItem();
            toolStripMenuItem5 = new ToolStripMenuItem();
            toolStripSeparator7 = new ToolStripSeparator();
            toolStripMenuItem6 = new ToolStripMenuItem();
            toolStripMenuItem7 = new ToolStripMenuItem();
            toolStripSeparator8 = new ToolStripSeparator();
            toolStripMenuItem8 = new ToolStripMenuItem();
            toolStripMenuItem9 = new ToolStripMenuItem();
            toolStripMenuItem10 = new ToolStripMenuItem();
            toolStripMenuItem11 = new ToolStripMenuItem();
            toolStripSeparator9 = new ToolStripSeparator();
            toolStripMenuItem12 = new ToolStripMenuItem();
            toolStripMenuItem13 = new ToolStripMenuItem();
            toolStripMenuItem14 = new ToolStripMenuItem();
            toolStripSeparator10 = new ToolStripSeparator();
            toolStripMenuItem15 = new ToolStripMenuItem();
            toolStripMenuItem16 = new ToolStripMenuItem();
            toolStripMenuItem17 = new ToolStripMenuItem();
            toolStripMenuItem18 = new ToolStripMenuItem();
            toolStripMenuItem19 = new ToolStripMenuItem();
            toolStripMenuItem20 = new ToolStripMenuItem();
            fontToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem21 = new ToolStripMenuItem();
            toolStripMenuItem22 = new ToolStripMenuItem();
            toolStripMenuItem23 = new ToolStripMenuItem();
            toolStripMenuItem24 = new ToolStripMenuItem();
            toolStripMenuItem25 = new ToolStripMenuItem();
            toolStripSeparator11 = new ToolStripSeparator();
            toolStripMenuItem26 = new ToolStripMenuItem();
            fontDialog1 = new FontDialog();
            toolStripSeparator1 = new ToolStripSeparator();
            toolStripMenuItem27 = new ToolStripMenuItem();
            toolStripMenuItem28 = new ToolStripMenuItem();
            tabControl1.SuspendLayout();
            tabPage2.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage2);
            tabControl1.DrawMode = TabDrawMode.OwnerDrawFixed;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.Padding = new Point(12, 6);
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(799, 451);
            tabControl1.TabIndex = 0;
            tabControl1.DrawItem += tabControl1_DrawItem;
            tabControl1.Selecting += tabControl1_Selecting;
            tabControl1.MouseDown += tabControl1_MouseDown;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(menuStrip1);
            tabPage2.Location = new Point(4, 30);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(791, 417);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "+";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { toolStripMenuItem1, toolStripMenuItem9, toolStripMenuItem16, toolStripMenuItem22 });
            menuStrip1.Location = new Point(3, 3);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(785, 24);
            menuStrip1.TabIndex = 2;
            menuStrip1.Text = "menuStrip2";
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { toolStripMenuItem2, toolStripMenuItem3, toolStripSeparator6, toolStripMenuItem4, toolStripMenuItem5, toolStripSeparator7, toolStripMenuItem6, toolStripMenuItem7, toolStripSeparator8, toolStripMenuItem8 });
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(37, 20);
            toolStripMenuItem1.Text = "&File";
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.Image = (Image)resources.GetObject("toolStripMenuItem2.Image");
            toolStripMenuItem2.ImageTransparentColor = Color.Magenta;
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.ShortcutKeys = Keys.Control | Keys.N;
            toolStripMenuItem2.Size = new Size(216, 22);
            toolStripMenuItem2.Text = "&New";
            toolStripMenuItem2.Click += newToolStripMenuItem_Click;
            // 
            // toolStripMenuItem3
            // 
            toolStripMenuItem3.Image = (Image)resources.GetObject("toolStripMenuItem3.Image");
            toolStripMenuItem3.ImageTransparentColor = Color.Magenta;
            toolStripMenuItem3.Name = "toolStripMenuItem3";
            toolStripMenuItem3.ShortcutKeys = Keys.Control | Keys.O;
            toolStripMenuItem3.Size = new Size(216, 22);
            toolStripMenuItem3.Text = "&Open";
            toolStripMenuItem3.Click += openToolStripMenuItem1_Click;
            // 
            // toolStripSeparator6
            // 
            toolStripSeparator6.Name = "toolStripSeparator6";
            toolStripSeparator6.Size = new Size(213, 6);
            // 
            // toolStripMenuItem4
            // 
            toolStripMenuItem4.Image = (Image)resources.GetObject("toolStripMenuItem4.Image");
            toolStripMenuItem4.ImageTransparentColor = Color.Magenta;
            toolStripMenuItem4.Name = "toolStripMenuItem4";
            toolStripMenuItem4.ShortcutKeys = Keys.Control | Keys.S;
            toolStripMenuItem4.Size = new Size(216, 22);
            toolStripMenuItem4.Text = "&Save";
            toolStripMenuItem4.Click += saveToolStripMenuItem1_Click;
            // 
            // toolStripMenuItem5
            // 
            toolStripMenuItem5.Name = "toolStripMenuItem5";
            toolStripMenuItem5.ShortcutKeys = Keys.Control | Keys.Shift | Keys.S;
            toolStripMenuItem5.Size = new Size(216, 22);
            toolStripMenuItem5.Text = "Save &As";
            toolStripMenuItem5.Click += saveAsToolStripMenuItem1_Click;
            // 
            // toolStripSeparator7
            // 
            toolStripSeparator7.Name = "toolStripSeparator7";
            toolStripSeparator7.Size = new Size(213, 6);
            // 
            // toolStripMenuItem6
            // 
            toolStripMenuItem6.Image = (Image)resources.GetObject("toolStripMenuItem6.Image");
            toolStripMenuItem6.ImageTransparentColor = Color.Magenta;
            toolStripMenuItem6.Name = "toolStripMenuItem6";
            toolStripMenuItem6.ShortcutKeys = Keys.Control | Keys.P;
            toolStripMenuItem6.Size = new Size(216, 22);
            toolStripMenuItem6.Text = "&Print";
            toolStripMenuItem6.Click += printToolStripMenuItem_Click;
            // 
            // toolStripMenuItem7
            // 
            toolStripMenuItem7.Image = (Image)resources.GetObject("toolStripMenuItem7.Image");
            toolStripMenuItem7.ImageTransparentColor = Color.Magenta;
            toolStripMenuItem7.Name = "toolStripMenuItem7";
            toolStripMenuItem7.ShortcutKeys = Keys.Control | Keys.Shift | Keys.P;
            toolStripMenuItem7.Size = new Size(216, 22);
            toolStripMenuItem7.Text = "Print Pre&view";
            toolStripMenuItem7.Click += printPreviewToolStripMenuItem_Click_1;
            // 
            // toolStripSeparator8
            // 
            toolStripSeparator8.Name = "toolStripSeparator8";
            toolStripSeparator8.Size = new Size(213, 6);
            // 
            // toolStripMenuItem8
            // 
            toolStripMenuItem8.Name = "toolStripMenuItem8";
            toolStripMenuItem8.ShortcutKeys = Keys.Alt | Keys.F4;
            toolStripMenuItem8.Size = new Size(216, 22);
            toolStripMenuItem8.Text = "E&xit";
            toolStripMenuItem8.Click += toolStripMenuItem8_Click;
            // 
            // toolStripMenuItem9
            // 
            toolStripMenuItem9.DropDownItems.AddRange(new ToolStripItem[] { toolStripMenuItem10, toolStripMenuItem11, toolStripSeparator9, toolStripMenuItem12, toolStripMenuItem13, toolStripMenuItem14, toolStripSeparator1, toolStripMenuItem27, toolStripMenuItem28, toolStripSeparator10, toolStripMenuItem15 });
            toolStripMenuItem9.Name = "toolStripMenuItem9";
            toolStripMenuItem9.Size = new Size(39, 20);
            toolStripMenuItem9.Text = "&Edit";
            // 
            // toolStripMenuItem10
            // 
            toolStripMenuItem10.Name = "toolStripMenuItem10";
            toolStripMenuItem10.ShortcutKeys = Keys.Control | Keys.Z;
            toolStripMenuItem10.Size = new Size(174, 22);
            toolStripMenuItem10.Text = "&Undo";
            toolStripMenuItem10.Click += undoToolStripMenuItem_Click;
            // 
            // toolStripMenuItem11
            // 
            toolStripMenuItem11.Name = "toolStripMenuItem11";
            toolStripMenuItem11.ShortcutKeys = Keys.Control | Keys.Shift | Keys.Z;
            toolStripMenuItem11.Size = new Size(174, 22);
            toolStripMenuItem11.Text = "&Redo";
            toolStripMenuItem11.Click += redoToolStripMenuItem_Click;
            // 
            // toolStripSeparator9
            // 
            toolStripSeparator9.Name = "toolStripSeparator9";
            toolStripSeparator9.Size = new Size(171, 6);
            // 
            // toolStripMenuItem12
            // 
            toolStripMenuItem12.Image = (Image)resources.GetObject("toolStripMenuItem12.Image");
            toolStripMenuItem12.ImageTransparentColor = Color.Magenta;
            toolStripMenuItem12.Name = "toolStripMenuItem12";
            toolStripMenuItem12.ShortcutKeys = Keys.Control | Keys.X;
            toolStripMenuItem12.Size = new Size(174, 22);
            toolStripMenuItem12.Text = "Cu&t";
            toolStripMenuItem12.Click += cutToolStripMenuItem1_Click;
            // 
            // toolStripMenuItem13
            // 
            toolStripMenuItem13.Image = (Image)resources.GetObject("toolStripMenuItem13.Image");
            toolStripMenuItem13.ImageTransparentColor = Color.Magenta;
            toolStripMenuItem13.Name = "toolStripMenuItem13";
            toolStripMenuItem13.ShortcutKeys = Keys.Control | Keys.C;
            toolStripMenuItem13.Size = new Size(174, 22);
            toolStripMenuItem13.Text = "&Copy";
            toolStripMenuItem13.Click += copyToolStripMenuItem1_Click;
            // 
            // toolStripMenuItem14
            // 
            toolStripMenuItem14.Image = (Image)resources.GetObject("toolStripMenuItem14.Image");
            toolStripMenuItem14.ImageTransparentColor = Color.Magenta;
            toolStripMenuItem14.Name = "toolStripMenuItem14";
            toolStripMenuItem14.ShortcutKeys = Keys.Control | Keys.V;
            toolStripMenuItem14.Size = new Size(174, 22);
            toolStripMenuItem14.Text = "&Paste";
            toolStripMenuItem14.Click += pasteToolStripMenuItem1_Click;
            // 
            // toolStripSeparator10
            // 
            toolStripSeparator10.Name = "toolStripSeparator10";
            toolStripSeparator10.Size = new Size(171, 6);
            // 
            // toolStripMenuItem15
            // 
            toolStripMenuItem15.Name = "toolStripMenuItem15";
            toolStripMenuItem15.ShortcutKeys = Keys.Control | Keys.A;
            toolStripMenuItem15.Size = new Size(174, 22);
            toolStripMenuItem15.Text = "Select &All";
            toolStripMenuItem15.Click += toolStripMenuItem15_Click;
            // 
            // toolStripMenuItem16
            // 
            toolStripMenuItem16.DropDownItems.AddRange(new ToolStripItem[] { toolStripMenuItem17, fontToolStripMenuItem, toolStripMenuItem21 });
            toolStripMenuItem16.Name = "toolStripMenuItem16";
            toolStripMenuItem16.Size = new Size(44, 20);
            toolStripMenuItem16.Text = "View";
            // 
            // toolStripMenuItem17
            // 
            toolStripMenuItem17.DropDownItems.AddRange(new ToolStripItem[] { toolStripMenuItem18, toolStripMenuItem19, toolStripMenuItem20 });
            toolStripMenuItem17.Name = "toolStripMenuItem17";
            toolStripMenuItem17.Size = new Size(134, 22);
            toolStripMenuItem17.Text = "Zoom";
            // 
            // toolStripMenuItem18
            // 
            toolStripMenuItem18.Name = "toolStripMenuItem18";
            toolStripMenuItem18.ShortcutKeyDisplayString = "Ctrl+Plus";
            toolStripMenuItem18.ShortcutKeys = Keys.Control | Keys.Oemplus;
            toolStripMenuItem18.Size = new Size(196, 22);
            toolStripMenuItem18.Text = "Zoom In";
            toolStripMenuItem18.Click += zoomInToolStripMenuItem_Click;
            // 
            // toolStripMenuItem19
            // 
            toolStripMenuItem19.Name = "toolStripMenuItem19";
            toolStripMenuItem19.ShortcutKeyDisplayString = "Ctrl+Minus";
            toolStripMenuItem19.ShortcutKeys = Keys.Control | Keys.OemMinus;
            toolStripMenuItem19.Size = new Size(196, 22);
            toolStripMenuItem19.Text = "Zoom Out";
            toolStripMenuItem19.Click += zoomOutToolStripMenuItem_Click;
            // 
            // toolStripMenuItem20
            // 
            toolStripMenuItem20.Name = "toolStripMenuItem20";
            toolStripMenuItem20.Size = new Size(196, 22);
            toolStripMenuItem20.Text = "Default Zoom";
            toolStripMenuItem20.Click += defaultZoomToolStripMenuItem_Click;
            // 
            // fontToolStripMenuItem
            // 
            fontToolStripMenuItem.Name = "fontToolStripMenuItem";
            fontToolStripMenuItem.Size = new Size(134, 22);
            fontToolStripMenuItem.Text = "Font";
            fontToolStripMenuItem.Click += fontToolStripMenuItem_Click;
            // 
            // toolStripMenuItem21
            // 
            toolStripMenuItem21.Checked = true;
            toolStripMenuItem21.CheckState = CheckState.Checked;
            toolStripMenuItem21.Name = "toolStripMenuItem21";
            toolStripMenuItem21.Size = new Size(134, 22);
            toolStripMenuItem21.Text = "Word Wrap";
            toolStripMenuItem21.Click += toolStripMenuItem21_Click;
            // 
            // toolStripMenuItem22
            // 
            toolStripMenuItem22.DropDownItems.AddRange(new ToolStripItem[] { toolStripMenuItem23, toolStripMenuItem24, toolStripMenuItem25, toolStripSeparator11, toolStripMenuItem26 });
            toolStripMenuItem22.Name = "toolStripMenuItem22";
            toolStripMenuItem22.Size = new Size(44, 20);
            toolStripMenuItem22.Text = "&Help";
            // 
            // toolStripMenuItem23
            // 
            toolStripMenuItem23.Name = "toolStripMenuItem23";
            toolStripMenuItem23.Size = new Size(122, 22);
            toolStripMenuItem23.Text = "&Contents";
            // 
            // toolStripMenuItem24
            // 
            toolStripMenuItem24.Name = "toolStripMenuItem24";
            toolStripMenuItem24.Size = new Size(122, 22);
            toolStripMenuItem24.Text = "&Index";
            // 
            // toolStripMenuItem25
            // 
            toolStripMenuItem25.Name = "toolStripMenuItem25";
            toolStripMenuItem25.Size = new Size(122, 22);
            toolStripMenuItem25.Text = "&Search";
            // 
            // toolStripSeparator11
            // 
            toolStripSeparator11.Name = "toolStripSeparator11";
            toolStripSeparator11.Size = new Size(119, 6);
            // 
            // toolStripMenuItem26
            // 
            toolStripMenuItem26.Name = "toolStripMenuItem26";
            toolStripMenuItem26.Size = new Size(122, 22);
            toolStripMenuItem26.Text = "&About...";
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(171, 6);
            // 
            // toolStripMenuItem27
            // 
            toolStripMenuItem27.Name = "toolStripMenuItem27";
            toolStripMenuItem27.ShortcutKeys = Keys.Control | Keys.F;
            toolStripMenuItem27.Size = new Size(180, 22);
            toolStripMenuItem27.Text = "Find";
            toolStripMenuItem27.Click += toolStripMenuItem27_Click;
            // 
            // toolStripMenuItem28
            // 
            toolStripMenuItem28.Name = "toolStripMenuItem28";
            toolStripMenuItem28.ShortcutKeys = Keys.Control | Keys.H;
            toolStripMenuItem28.Size = new Size(180, 22);
            toolStripMenuItem28.Text = "Replace";
            toolStripMenuItem28.Click += toolStripMenuItem28_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(800, 450);
            Controls.Add(tabControl1);
            MinimumSize = new Size(300, 200);
            Name = "Form1";
            Text = "Litera";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            tabControl1.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private FontDialog fontDialog1;
        private TabPage tabPage2;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem toolStripMenuItem2;
        private ToolStripMenuItem toolStripMenuItem3;
        private ToolStripSeparator toolStripSeparator6;
        private ToolStripMenuItem toolStripMenuItem4;
        private ToolStripMenuItem toolStripMenuItem5;
        private ToolStripSeparator toolStripSeparator7;
        private ToolStripMenuItem toolStripMenuItem6;
        private ToolStripMenuItem toolStripMenuItem7;
        private ToolStripSeparator toolStripSeparator8;
        private ToolStripMenuItem toolStripMenuItem8;
        private ToolStripMenuItem toolStripMenuItem9;
        private ToolStripMenuItem toolStripMenuItem10;
        private ToolStripMenuItem toolStripMenuItem11;
        private ToolStripSeparator toolStripSeparator9;
        private ToolStripMenuItem toolStripMenuItem12;
        private ToolStripMenuItem toolStripMenuItem13;
        private ToolStripMenuItem toolStripMenuItem14;
        private ToolStripSeparator toolStripSeparator10;
        private ToolStripMenuItem toolStripMenuItem15;
        private ToolStripMenuItem toolStripMenuItem16;
        private ToolStripMenuItem toolStripMenuItem17;
        private ToolStripMenuItem toolStripMenuItem18;
        private ToolStripMenuItem toolStripMenuItem19;
        private ToolStripMenuItem toolStripMenuItem20;
        private ToolStripMenuItem toolStripMenuItem21;
        private ToolStripMenuItem toolStripMenuItem22;
        private ToolStripMenuItem toolStripMenuItem23;
        private ToolStripMenuItem toolStripMenuItem24;
        private ToolStripMenuItem toolStripMenuItem25;
        private ToolStripSeparator toolStripSeparator11;
        private ToolStripMenuItem toolStripMenuItem26;
        private ToolStripMenuItem fontToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem toolStripMenuItem27;
        private ToolStripMenuItem toolStripMenuItem28;
        //private ToolStripContainer toolStripContainer1;
    }
}
