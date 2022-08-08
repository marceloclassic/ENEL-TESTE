namespace Teste.UI
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
            this.listViewNumeros = new System.Windows.Forms.ListView();
            this.Números = new System.Windows.Forms.ColumnHeader();
            this.Números.Text = "Números";
            this.SuspendLayout();
            // 
            // listViewNumeros
            // 
            this.listViewNumeros.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Números});
            this.listViewNumeros.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewNumeros.Location = new System.Drawing.Point(0, 0);
            this.listViewNumeros.Name = "listViewNumeros";
            this.listViewNumeros.Size = new System.Drawing.Size(338, 450);
            this.listViewNumeros.TabIndex = 0;
            this.listViewNumeros.UseCompatibleStateImageBehavior = false;
            this.listViewNumeros.View = System.Windows.Forms.View.Details;
            this.listViewNumeros.DoubleClick += ListViewNumeros_DoubleClick;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(338, 450);
            this.Controls.Add(this.listViewNumeros);
            this.Name = "Form1";
            this.Text = "Teste";
            this.ResumeLayout(false);

        }
        #endregion

        private ListView listViewNumeros;
        private ColumnHeader Números;
    }
}