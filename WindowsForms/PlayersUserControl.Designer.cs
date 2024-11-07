namespace WindowsForms
{
    partial class PlayersUserControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayersUserControl));
            panel1 = new Panel();
            label3 = new Label();
            lbAllPlayers = new ListBox();
            label1 = new Label();
            lblPlayer = new Label();
            panel2 = new Panel();
            label4 = new Label();
            lbFavPlayers = new ListBox();
            label2 = new Label();
            btnMoveToFavourite = new Button();
            btnMoveToAll = new Button();
            btnSelectPLayer = new Button();
            pbPlayer = new PictureBox();
            btnAddImg = new Button();
            lvPlayer = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            lvLocation = new ListView();
            columnHeader4 = new ColumnHeader();
            columnHeader5 = new ColumnHeader();
            columnHeader6 = new ColumnHeader();
            columnHeader7 = new ColumnHeader();
            contextMenuStrip = new ContextMenuStrip(components);
            movePlayerToFavouritesToolStripMenuItem = new ToolStripMenuItem();
            movePlayerToAllPlayersToolStripMenuItem = new ToolStripMenuItem();
            saveFavouritesToolStripMenuItem = new ToolStripMenuItem();
            printPlayerStatsToolStripMenuItem = new ToolStripMenuItem();
            printMatchStatsToolStripMenuItem = new ToolStripMenuItem();
            printDocument = new System.Drawing.Printing.PrintDocument();
            printDialog = new PrintDialog();
            printPreviewDialog = new PrintPreviewDialog();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbPlayer).BeginInit();
            contextMenuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            resources.ApplyResources(panel1, "panel1");
            panel1.Controls.Add(label3);
            panel1.Controls.Add(lbAllPlayers);
            panel1.Controls.Add(label1);
            panel1.Name = "panel1";
            // 
            // label3
            // 
            resources.ApplyResources(label3, "label3");
            label3.Name = "label3";
            // 
            // lbAllPlayers
            // 
            resources.ApplyResources(lbAllPlayers, "lbAllPlayers");
            lbAllPlayers.AllowDrop = true;
            lbAllPlayers.FormattingEnabled = true;
            lbAllPlayers.Name = "lbAllPlayers";
            lbAllPlayers.SelectionMode = SelectionMode.MultiExtended;
            lbAllPlayers.SelectedIndexChanged += lbAllPlayers_SelectedIndexChanged;
            lbAllPlayers.MouseDown += lbAllPlayers_MouseDown;
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
            // 
            // lblPlayer
            // 
            resources.ApplyResources(lblPlayer, "lblPlayer");
            lblPlayer.Name = "lblPlayer";
            // 
            // panel2
            // 
            resources.ApplyResources(panel2, "panel2");
            panel2.Controls.Add(label4);
            panel2.Controls.Add(lbFavPlayers);
            panel2.Controls.Add(label2);
            panel2.Name = "panel2";
            panel2.Paint += panel2_Paint;
            // 
            // label4
            // 
            resources.ApplyResources(label4, "label4");
            label4.Name = "label4";
            // 
            // lbFavPlayers
            // 
            resources.ApplyResources(lbFavPlayers, "lbFavPlayers");
            lbFavPlayers.AllowDrop = true;
            lbFavPlayers.FormattingEnabled = true;
            lbFavPlayers.Name = "lbFavPlayers";
            lbFavPlayers.SelectionMode = SelectionMode.MultiExtended;
            lbFavPlayers.MouseDown += lbFavPlayers_MouseDown;
            // 
            // label2
            // 
            resources.ApplyResources(label2, "label2");
            label2.Name = "label2";
            // 
            // btnMoveToFavourite
            // 
            resources.ApplyResources(btnMoveToFavourite, "btnMoveToFavourite");
            btnMoveToFavourite.Name = "btnMoveToFavourite";
            btnMoveToFavourite.UseVisualStyleBackColor = true;
            btnMoveToFavourite.Click += btnMoveToFavourite_Click;
            // 
            // btnMoveToAll
            // 
            resources.ApplyResources(btnMoveToAll, "btnMoveToAll");
            btnMoveToAll.Name = "btnMoveToAll";
            btnMoveToAll.UseVisualStyleBackColor = true;
            btnMoveToAll.Click += btnMoveToAll_Click;
            // 
            // btnSelectPLayer
            // 
            resources.ApplyResources(btnSelectPLayer, "btnSelectPLayer");
            btnSelectPLayer.Name = "btnSelectPLayer";
            btnSelectPLayer.UseVisualStyleBackColor = true;
            btnSelectPLayer.Click += btnSelectPLayer_Click;
            // 
            // pbPlayer
            // 
            resources.ApplyResources(pbPlayer, "pbPlayer");
            pbPlayer.Name = "pbPlayer";
            pbPlayer.TabStop = false;
            // 
            // btnAddImg
            // 
            resources.ApplyResources(btnAddImg, "btnAddImg");
            btnAddImg.Name = "btnAddImg";
            btnAddImg.UseVisualStyleBackColor = true;
            btnAddImg.Click += btnAddImg_Click;
            // 
            // lvPlayer
            // 
            resources.ApplyResources(lvPlayer, "lvPlayer");
            lvPlayer.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3 });
            lvPlayer.Name = "lvPlayer";
            lvPlayer.Sorting = SortOrder.Ascending;
            lvPlayer.UseCompatibleStateImageBehavior = false;
            lvPlayer.View = View.Details;
            // 
            // columnHeader1
            // 
            resources.ApplyResources(columnHeader1, "columnHeader1");
            // 
            // columnHeader2
            // 
            resources.ApplyResources(columnHeader2, "columnHeader2");
            // 
            // columnHeader3
            // 
            resources.ApplyResources(columnHeader3, "columnHeader3");
            // 
            // lvLocation
            // 
            resources.ApplyResources(lvLocation, "lvLocation");
            lvLocation.Columns.AddRange(new ColumnHeader[] { columnHeader4, columnHeader5, columnHeader6, columnHeader7 });
            lvLocation.Name = "lvLocation";
            lvLocation.UseCompatibleStateImageBehavior = false;
            lvLocation.View = View.Details;
            // 
            // columnHeader4
            // 
            resources.ApplyResources(columnHeader4, "columnHeader4");
            // 
            // columnHeader5
            // 
            resources.ApplyResources(columnHeader5, "columnHeader5");
            // 
            // columnHeader6
            // 
            resources.ApplyResources(columnHeader6, "columnHeader6");
            // 
            // columnHeader7
            // 
            resources.ApplyResources(columnHeader7, "columnHeader7");
            // 
            // contextMenuStrip
            // 
            resources.ApplyResources(contextMenuStrip, "contextMenuStrip");
            contextMenuStrip.ImageScalingSize = new Size(20, 20);
            contextMenuStrip.Items.AddRange(new ToolStripItem[] { movePlayerToFavouritesToolStripMenuItem, movePlayerToAllPlayersToolStripMenuItem, saveFavouritesToolStripMenuItem, printPlayerStatsToolStripMenuItem, printMatchStatsToolStripMenuItem });
            contextMenuStrip.Name = "contextMenuStrip1";
            contextMenuStrip.Opening += contextMenuStrip_Opening;
            // 
            // movePlayerToFavouritesToolStripMenuItem
            // 
            resources.ApplyResources(movePlayerToFavouritesToolStripMenuItem, "movePlayerToFavouritesToolStripMenuItem");
            movePlayerToFavouritesToolStripMenuItem.Name = "movePlayerToFavouritesToolStripMenuItem";
            movePlayerToFavouritesToolStripMenuItem.Click += movePlayerToFavouritesToolStripMenuItem_Click;
            // 
            // movePlayerToAllPlayersToolStripMenuItem
            // 
            resources.ApplyResources(movePlayerToAllPlayersToolStripMenuItem, "movePlayerToAllPlayersToolStripMenuItem");
            movePlayerToAllPlayersToolStripMenuItem.Name = "movePlayerToAllPlayersToolStripMenuItem";
            movePlayerToAllPlayersToolStripMenuItem.Click += movePlayerToAllPlayersToolStripMenuItem_Click;
            // 
            // saveFavouritesToolStripMenuItem
            // 
            resources.ApplyResources(saveFavouritesToolStripMenuItem, "saveFavouritesToolStripMenuItem");
            saveFavouritesToolStripMenuItem.Name = "saveFavouritesToolStripMenuItem";
            saveFavouritesToolStripMenuItem.Click += saveFavouritesToolStripMenuItem_Click;
            // 
            // printPlayerStatsToolStripMenuItem
            // 
            resources.ApplyResources(printPlayerStatsToolStripMenuItem, "printPlayerStatsToolStripMenuItem");
            printPlayerStatsToolStripMenuItem.Name = "printPlayerStatsToolStripMenuItem";
            printPlayerStatsToolStripMenuItem.Click += printPlayerStatsToolStripMenuItem_Click;
            // 
            // printMatchStatsToolStripMenuItem
            // 
            resources.ApplyResources(printMatchStatsToolStripMenuItem, "printMatchStatsToolStripMenuItem");
            printMatchStatsToolStripMenuItem.Name = "printMatchStatsToolStripMenuItem";
            printMatchStatsToolStripMenuItem.Click += printMatchStatsToolStripMenuItem_Click;
            // 
            // printDocument
            // 
            printDocument.EndPrint += printDocument_EndPrint;
            printDocument.PrintPage += printDocument_PrintPage;
            // 
            // printDialog
            // 
            printDialog.Document = printDocument;
            printDialog.UseEXDialog = true;
            // 
            // printPreviewDialog
            // 
            resources.ApplyResources(printPreviewDialog, "printPreviewDialog");
            printPreviewDialog.Document = printDocument;
            printPreviewDialog.Name = "printPreviewDialog";
            // 
            // PlayersUserControl
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lvLocation);
            Controls.Add(lvPlayer);
            Controls.Add(btnAddImg);
            Controls.Add(pbPlayer);
            Controls.Add(btnSelectPLayer);
            Controls.Add(lblPlayer);
            Controls.Add(btnMoveToAll);
            Controls.Add(btnMoveToFavourite);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "PlayersUserControl";
            Load += PlayersUserControl_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbPlayer).EndInit();
            contextMenuStrip.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Button btnMoveToFavourite;
        private Button btnMoveToAll;
        private Label label1;
        private Label label2;
        private ListBox lbAllPlayers;
        private ListBox lbFavPlayers;
        private Label lblPlayer;
        private Button btnSelectPLayer;
        private PictureBox pbPlayer;
        private Button btnAddImg;
        private ListView lvPlayer;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ListView lvLocation;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader5;
        private ColumnHeader columnHeader6;
        private ColumnHeader columnHeader7;
        private ContextMenuStrip contextMenuStrip;
        private ToolStripMenuItem movePlayerToFavouritesToolStripMenuItem;
        private ToolStripMenuItem movePlayerToAllPlayersToolStripMenuItem;
        private Label label3;
        private Label label4;
        private ToolStripMenuItem saveFavouritesToolStripMenuItem;
        private ToolStripMenuItem printPlayerStatsToolStripMenuItem;
        private ToolStripMenuItem printMatchStatsToolStripMenuItem;
        private System.Drawing.Printing.PrintDocument printDocument;
        private PrintDialog printDialog;
        private PrintPreviewDialog printPreviewDialog;
    }
}
