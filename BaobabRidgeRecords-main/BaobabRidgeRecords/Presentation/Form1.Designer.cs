namespace BaobabRidgeRecords
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
            dgvAnimal = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            btnAdd = new Button();
            btnSaveChanges = new Button();
            btnClear = new Button();
            label6 = new Label();
            btnSearch = new Button();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            label12 = new Label();
            label13 = new Label();
            label14 = new Label();
            label15 = new Label();
            label16 = new Label();
            btnGenerateSummary = new Button();
            btnDelete = new Button();
            label17 = new Label();
            txtAnimalID = new TextBox();
            txtName = new TextBox();
            txtSpecies = new TextBox();
            txtAge = new TextBox();
            txtRecoveryScore = new TextBox();
            txtSearchAnimalID = new TextBox();
            lblTotalAnimals = new Label();
            lblAverageAge = new Label();
            lblAverageScore = new Label();
            lblReleaseReady = new Label();
            lblCritical = new Label();
            lblSerious = new Label();
            lblStable = new Label();
            lblRecovering = new Label();
            groupBoxAnimalDetails = new GroupBox();
            groupBoxSummary = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)dgvAnimal).BeginInit();
            groupBoxAnimalDetails.SuspendLayout();
            groupBoxSummary.SuspendLayout();
            SuspendLayout();
            // 
            // dgvAnimal
            // 
            dgvAnimal.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAnimal.Dock = DockStyle.Bottom;
            dgvAnimal.Location = new Point(0, 414);
            dgvAnimal.Name = "dgvAnimal";
            dgvAnimal.ReadOnly = true;
            dgvAnimal.RowHeadersWidth = 51;
            dgvAnimal.Size = new Size(1082, 189);
            dgvAnimal.TabIndex = 0;
            dgvAnimal.CellClick += dgvAnimal_CellClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(42, 45);
            label1.Name = "label1";
            label1.Size = new Size(80, 20);
            label1.TabIndex = 2;
            label1.Text = "Animal ID:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(42, 84);
            label2.Name = "label2";
            label2.Size = new Size(54, 20);
            label2.TabIndex = 3;
            label2.Text = "Name:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(42, 124);
            label3.Name = "label3";
            label3.Size = new Size(63, 20);
            label3.TabIndex = 4;
            label3.Text = "Species:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(42, 163);
            label4.Name = "label4";
            label4.Size = new Size(40, 20);
            label4.TabIndex = 5;
            label4.Text = "Age:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(42, 207);
            label5.Name = "label5";
            label5.Size = new Size(119, 20);
            label5.TabIndex = 6;
            label5.Text = "Recovery Score:";
            // 
            // btnAdd
            // 
            btnAdd.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAdd.Location = new Point(42, 268);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(94, 35);
            btnAdd.TabIndex = 7;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnSaveChanges
            // 
            btnSaveChanges.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSaveChanges.Location = new Point(157, 268);
            btnSaveChanges.Name = "btnSaveChanges";
            btnSaveChanges.Size = new Size(155, 35);
            btnSaveChanges.TabIndex = 8;
            btnSaveChanges.Text = "Save Changes";
            btnSaveChanges.UseVisualStyleBackColor = true;
            btnSaveChanges.Click += btnSaveChanges_Click;
            // 
            // btnClear
            // 
            btnClear.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClear.Location = new Point(337, 268);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(94, 35);
            btnClear.TabIndex = 9;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(11, 381);
            label6.Name = "label6";
            label6.Size = new Size(151, 20);
            label6.TabIndex = 10;
            label6.Text = "Search Animal by ID:";
            // 
            // btnSearch
            // 
            btnSearch.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSearch.Location = new Point(384, 379);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(94, 29);
            btnSearch.TabIndex = 12;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.Location = new Point(6, 75);
            label9.Name = "label9";
            label9.Size = new Size(104, 20);
            label9.TabIndex = 14;
            label9.Text = "Total Animals:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.Location = new Point(6, 115);
            label10.Name = "label10";
            label10.Size = new Size(101, 20);
            label10.TabIndex = 15;
            label10.Text = "Average Age:";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label11.Location = new Point(6, 153);
            label11.Name = "label11";
            label11.Size = new Size(112, 20);
            label11.TabIndex = 16;
            label11.Text = "Average Score:";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label12.Location = new Point(302, 75);
            label12.Name = "label12";
            label12.Size = new Size(60, 20);
            label12.TabIndex = 17;
            label12.Text = "Critical:";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label13.Location = new Point(302, 115);
            label13.Name = "label13";
            label13.Size = new Size(63, 20);
            label13.TabIndex = 18;
            label13.Text = "Serious:";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label14.Location = new Point(302, 153);
            label14.Name = "label14";
            label14.Size = new Size(55, 20);
            label14.TabIndex = 19;
            label14.Text = "Stable:";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label15.Location = new Point(302, 197);
            label15.Name = "label15";
            label15.Size = new Size(90, 20);
            label15.TabIndex = 20;
            label15.Text = "Recovering:";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label16.Location = new Point(6, 197);
            label16.Name = "label16";
            label16.Size = new Size(112, 20);
            label16.TabIndex = 21;
            label16.Text = "Release-Ready:";
            // 
            // btnGenerateSummary
            // 
            btnGenerateSummary.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGenerateSummary.Location = new Point(149, 20);
            btnGenerateSummary.Name = "btnGenerateSummary";
            btnGenerateSummary.Size = new Size(243, 35);
            btnGenerateSummary.TabIndex = 22;
            btnGenerateSummary.Text = "Generate Summary";
            btnGenerateSummary.UseVisualStyleBackColor = true;
            btnGenerateSummary.Click += btnGenerateSummary_Click;
            // 
            // btnDelete
            // 
            btnDelete.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDelete.Location = new Point(962, 372);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 29);
            btnDelete.TabIndex = 23;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label17.Location = new Point(11, 341);
            label17.Name = "label17";
            label17.Size = new Size(219, 25);
            label17.TabIndex = 24;
            label17.Text = "View All Animal Records";
            // 
            // txtAnimalID
            // 
            txtAnimalID.Location = new Point(167, 45);
            txtAnimalID.Name = "txtAnimalID";
            txtAnimalID.Size = new Size(209, 31);
            txtAnimalID.TabIndex = 25;
            // 
            // txtName
            // 
            txtName.Location = new Point(167, 84);
            txtName.Name = "txtName";
            txtName.Size = new Size(209, 31);
            txtName.TabIndex = 26;
            // 
            // txtSpecies
            // 
            txtSpecies.Location = new Point(167, 124);
            txtSpecies.Name = "txtSpecies";
            txtSpecies.Size = new Size(209, 31);
            txtSpecies.TabIndex = 27;
            // 
            // txtAge
            // 
            txtAge.Location = new Point(167, 163);
            txtAge.Name = "txtAge";
            txtAge.Size = new Size(209, 31);
            txtAge.TabIndex = 28;
            // 
            // txtRecoveryScore
            // 
            txtRecoveryScore.Location = new Point(167, 207);
            txtRecoveryScore.Name = "txtRecoveryScore";
            txtRecoveryScore.Size = new Size(209, 31);
            txtRecoveryScore.TabIndex = 29;
            // 
            // txtSearchAnimalID
            // 
            txtSearchAnimalID.Location = new Point(169, 379);
            txtSearchAnimalID.Name = "txtSearchAnimalID";
            txtSearchAnimalID.Size = new Size(209, 27);
            txtSearchAnimalID.TabIndex = 30;
            // 
            // lblTotalAnimals
            // 
            lblTotalAnimals.AutoSize = true;
            lblTotalAnimals.Location = new Point(154, 72);
            lblTotalAnimals.Name = "lblTotalAnimals";
            lblTotalAnimals.Size = new Size(19, 25);
            lblTotalAnimals.TabIndex = 31;
            lblTotalAnimals.Text = "-";
            // 
            // lblAverageAge
            // 
            lblAverageAge.AutoSize = true;
            lblAverageAge.Location = new Point(154, 115);
            lblAverageAge.Name = "lblAverageAge";
            lblAverageAge.Size = new Size(19, 25);
            lblAverageAge.TabIndex = 32;
            lblAverageAge.Text = "-";
            // 
            // lblAverageScore
            // 
            lblAverageScore.AutoSize = true;
            lblAverageScore.Location = new Point(155, 153);
            lblAverageScore.Name = "lblAverageScore";
            lblAverageScore.Size = new Size(19, 25);
            lblAverageScore.TabIndex = 33;
            lblAverageScore.Text = "-";
            // 
            // lblReleaseReady
            // 
            lblReleaseReady.AutoSize = true;
            lblReleaseReady.Location = new Point(155, 201);
            lblReleaseReady.Name = "lblReleaseReady";
            lblReleaseReady.Size = new Size(19, 25);
            lblReleaseReady.TabIndex = 34;
            lblReleaseReady.Text = "-";
            // 
            // lblCritical
            // 
            lblCritical.AutoSize = true;
            lblCritical.Location = new Point(419, 75);
            lblCritical.Name = "lblCritical";
            lblCritical.Size = new Size(19, 25);
            lblCritical.TabIndex = 35;
            lblCritical.Text = "-";
            // 
            // lblSerious
            // 
            lblSerious.AutoSize = true;
            lblSerious.Location = new Point(419, 115);
            lblSerious.Name = "lblSerious";
            lblSerious.Size = new Size(19, 25);
            lblSerious.TabIndex = 36;
            lblSerious.Text = "-";
            // 
            // lblStable
            // 
            lblStable.AutoSize = true;
            lblStable.Location = new Point(419, 153);
            lblStable.Name = "lblStable";
            lblStable.Size = new Size(19, 25);
            lblStable.TabIndex = 37;
            lblStable.Text = "-";
            // 
            // lblRecovering
            // 
            lblRecovering.AutoSize = true;
            lblRecovering.Location = new Point(419, 201);
            lblRecovering.Name = "lblRecovering";
            lblRecovering.Size = new Size(19, 25);
            lblRecovering.TabIndex = 38;
            lblRecovering.Text = "-";
            // 
            // groupBoxAnimalDetails
            // 
            groupBoxAnimalDetails.BackColor = SystemColors.ControlLight;
            groupBoxAnimalDetails.Controls.Add(txtRecoveryScore);
            groupBoxAnimalDetails.Controls.Add(label1);
            groupBoxAnimalDetails.Controls.Add(label2);
            groupBoxAnimalDetails.Controls.Add(label3);
            groupBoxAnimalDetails.Controls.Add(label4);
            groupBoxAnimalDetails.Controls.Add(label5);
            groupBoxAnimalDetails.Controls.Add(btnAdd);
            groupBoxAnimalDetails.Controls.Add(btnSaveChanges);
            groupBoxAnimalDetails.Controls.Add(btnClear);
            groupBoxAnimalDetails.Controls.Add(txtAnimalID);
            groupBoxAnimalDetails.Controls.Add(txtName);
            groupBoxAnimalDetails.Controls.Add(txtAge);
            groupBoxAnimalDetails.Controls.Add(txtSpecies);
            groupBoxAnimalDetails.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBoxAnimalDetails.Location = new Point(619, 29);
            groupBoxAnimalDetails.Name = "groupBoxAnimalDetails";
            groupBoxAnimalDetails.Size = new Size(437, 308);
            groupBoxAnimalDetails.TabIndex = 39;
            groupBoxAnimalDetails.TabStop = false;
            groupBoxAnimalDetails.Text = "Animal Details";
            // 
            // groupBoxSummary
            // 
            groupBoxSummary.BackColor = SystemColors.ControlLight;
            groupBoxSummary.Controls.Add(btnGenerateSummary);
            groupBoxSummary.Controls.Add(lblRecovering);
            groupBoxSummary.Controls.Add(label9);
            groupBoxSummary.Controls.Add(lblStable);
            groupBoxSummary.Controls.Add(label10);
            groupBoxSummary.Controls.Add(lblSerious);
            groupBoxSummary.Controls.Add(label11);
            groupBoxSummary.Controls.Add(lblCritical);
            groupBoxSummary.Controls.Add(label12);
            groupBoxSummary.Controls.Add(lblReleaseReady);
            groupBoxSummary.Controls.Add(label13);
            groupBoxSummary.Controls.Add(lblAverageScore);
            groupBoxSummary.Controls.Add(label14);
            groupBoxSummary.Controls.Add(lblAverageAge);
            groupBoxSummary.Controls.Add(label15);
            groupBoxSummary.Controls.Add(lblTotalAnimals);
            groupBoxSummary.Controls.Add(label16);
            groupBoxSummary.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBoxSummary.Location = new Point(11, 49);
            groupBoxSummary.Name = "groupBoxSummary";
            groupBoxSummary.Size = new Size(555, 251);
            groupBoxSummary.TabIndex = 40;
            groupBoxSummary.TabStop = false;
            groupBoxSummary.Text = "Summary";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1082, 603);
            Controls.Add(groupBoxSummary);
            Controls.Add(groupBoxAnimalDetails);
            Controls.Add(txtSearchAnimalID);
            Controls.Add(label17);
            Controls.Add(btnDelete);
            Controls.Add(btnSearch);
            Controls.Add(label6);
            Controls.Add(dgvAnimal);
            Name = "Form1";
            Text = "BaobabRidgeRecords";
            ((System.ComponentModel.ISupportInitialize)dgvAnimal).EndInit();
            groupBoxAnimalDetails.ResumeLayout(false);
            groupBoxAnimalDetails.PerformLayout();
            groupBoxSummary.ResumeLayout(false);
            groupBoxSummary.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvAnimal;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Button btnAdd;
        private Button btnSaveChanges;
        private Button btnClear;
        private Label label6;
        private Button btnSearch;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label13;
        private Label label14;
        private Label label15;
        private Label label16;
        private Button btnGenerateSummary;
        private Button btnDelete;
        private Label label17;
        private TextBox txtAnimalID;
        private TextBox txtName;
        private TextBox txtSpecies;
        private TextBox txtAge;
        private TextBox txtRecoveryScore;
        private TextBox txtSearchAnimalID;
        private Label lblTotalAnimals;
        private Label label18;
        private Label lblAverageScore;
        private Label lblReleaseReady;
        private Label lblCritical;
        private Label lblSerious;
        private Label lblStable;
        private Label lblRecovering;
        private Label lblAverageAge;
        private GroupBox groupBoxAnimalDetails;
        private GroupBox groupBoxSummary;
    }
}
