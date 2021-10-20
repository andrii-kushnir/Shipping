
namespace PostAPI
{
    partial class DeliveryCargo
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this._cbCargoCategory = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this._cbCategoryTariff = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // _cbCargoCategory
            // 
            this._cbCargoCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this._cbCargoCategory.FormattingEnabled = true;
            this._cbCargoCategory.Location = new System.Drawing.Point(186, 80);
            this._cbCargoCategory.Name = "_cbCargoCategory";
            this._cbCargoCategory.Size = new System.Drawing.Size(251, 28);
            this._cbCargoCategory.TabIndex = 26;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(35, 83);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(145, 20);
            this.label9.TabIndex = 25;
            this.label9.Text = "Категорія грузу:";
            // 
            // _cbCategoryTariff
            // 
            this._cbCategoryTariff.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this._cbCategoryTariff.FormattingEnabled = true;
            this._cbCategoryTariff.Location = new System.Drawing.Point(186, 24);
            this._cbCategoryTariff.Name = "_cbCategoryTariff";
            this._cbCategoryTariff.Size = new System.Drawing.Size(251, 28);
            this._cbCategoryTariff.TabIndex = 28;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(14, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 20);
            this.label1.TabIndex = 27;
            this.label1.Text = "Категорія тарифу:";
            // 
            // DeliveryCargo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 430);
            this.Controls.Add(this._cbCategoryTariff);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._cbCargoCategory);
            this.Controls.Add(this.label9);
            this.Name = "DeliveryCargo";
            this.Text = "DeliveryCargo";
            this.Load += new System.EventHandler(this.DeliveryCargo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox _cbCargoCategory;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox _cbCategoryTariff;
        private System.Windows.Forms.Label label1;
    }
}