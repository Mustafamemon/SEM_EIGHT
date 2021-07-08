namespace Q1
{
    partial class Form1
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
            this.first_num = new System.Windows.Forms.Label();
            this.second_num = new System.Windows.Forms.Label();
            this.input_1 = new System.Windows.Forms.TextBox();
            this.input_2 = new System.Windows.Forms.TextBox();
            this.add = new System.Windows.Forms.Button();
            this.subtract = new System.Windows.Forms.Button();
            this.multiply = new System.Windows.Forms.Button();
            this.divide = new System.Windows.Forms.Button();
            this.input_result = new System.Windows.Forms.TextBox();
            this.result = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // first_num
            // 
            this.first_num.AutoSize = true;
            this.first_num.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.first_num.Location = new System.Drawing.Point(28, 56);
            this.first_num.Name = "first_num";
            this.first_num.Size = new System.Drawing.Size(158, 24);
            this.first_num.TabIndex = 0;
            this.first_num.Text = "Enter first number";
            this.first_num.Click += new System.EventHandler(this.label1_Click);
            // 
            // second_num
            // 
            this.second_num.AutoSize = true;
            this.second_num.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.second_num.Location = new System.Drawing.Point(28, 83);
            this.second_num.Name = "second_num";
            this.second_num.Size = new System.Drawing.Size(194, 24);
            this.second_num.TabIndex = 1;
            this.second_num.Text = "Enter second number";
            this.second_num.Click += new System.EventHandler(this.label2_Click);
            // 
            // input_1
            // 
            this.input_1.Location = new System.Drawing.Point(263, 61);
            this.input_1.Name = "input_1";
            this.input_1.Size = new System.Drawing.Size(206, 20);
            this.input_1.TabIndex = 2;
            this.input_1.TextChanged += new System.EventHandler(this.input_1_TextChanged);
            // 
            // input_2
            // 
            this.input_2.Location = new System.Drawing.Point(263, 88);
            this.input_2.Name = "input_2";
            this.input_2.Size = new System.Drawing.Size(206, 20);
            this.input_2.TabIndex = 3;
            this.input_2.TextChanged += new System.EventHandler(this.input_2_TextChanged);
            // 
            // add
            // 
            this.add.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.add.Location = new System.Drawing.Point(32, 128);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(75, 42);
            this.add.TabIndex = 4;
            this.add.Text = "+";
            this.add.UseVisualStyleBackColor = true;
            this.add.Click += new System.EventHandler(this.add_Click);
            // 
            // subtract
            // 
            this.subtract.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subtract.Location = new System.Drawing.Point(147, 128);
            this.subtract.Name = "subtract";
            this.subtract.Size = new System.Drawing.Size(75, 42);
            this.subtract.TabIndex = 5;
            this.subtract.Text = "-";
            this.subtract.UseVisualStyleBackColor = true;
            this.subtract.Click += new System.EventHandler(this.subtract_Click);
            // 
            // multiply
            // 
            this.multiply.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.multiply.Location = new System.Drawing.Point(263, 128);
            this.multiply.Name = "multiply";
            this.multiply.Size = new System.Drawing.Size(75, 42);
            this.multiply.TabIndex = 6;
            this.multiply.Text = "*";
            this.multiply.UseVisualStyleBackColor = true;
            this.multiply.Click += new System.EventHandler(this.multiply_Click);
            // 
            // divide
            // 
            this.divide.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.divide.Location = new System.Drawing.Point(394, 128);
            this.divide.Name = "divide";
            this.divide.Size = new System.Drawing.Size(75, 42);
            this.divide.TabIndex = 7;
            this.divide.Text = "/";
            this.divide.UseVisualStyleBackColor = true;
            this.divide.Click += new System.EventHandler(this.divide_Click);
            // 
            // input_result
            // 
            this.input_result.Location = new System.Drawing.Point(263, 213);
            this.input_result.Name = "input_result";
            this.input_result.Size = new System.Drawing.Size(206, 20);
            this.input_result.TabIndex = 8;
            // 
            // result
            // 
            this.result.AutoSize = true;
            this.result.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.result.Location = new System.Drawing.Point(28, 208);
            this.result.Name = "result";
            this.result.Size = new System.Drawing.Size(62, 24);
            this.result.TabIndex = 9;
            this.result.Text = "Result";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(381, 264);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 29);
            this.button1.TabIndex = 10;
            this.button1.Text = "Exit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(141, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(211, 31);
            this.label1.TabIndex = 11;
            this.label1.Text = "Basic Calculator";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 314);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.result);
            this.Controls.Add(this.input_result);
            this.Controls.Add(this.divide);
            this.Controls.Add(this.multiply);
            this.Controls.Add(this.subtract);
            this.Controls.Add(this.add);
            this.Controls.Add(this.input_2);
            this.Controls.Add(this.input_1);
            this.Controls.Add(this.second_num);
            this.Controls.Add(this.first_num);
            this.Name = "Form1";
            this.Text = "Calculator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label first_num;
        private System.Windows.Forms.Label second_num;
        private System.Windows.Forms.TextBox input_1;
        private System.Windows.Forms.TextBox input_2;
        private System.Windows.Forms.Button add;
        private System.Windows.Forms.Button subtract;
        private System.Windows.Forms.Button multiply;
        private System.Windows.Forms.Button divide;
        private System.Windows.Forms.TextBox input_result;
        private System.Windows.Forms.Label result;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
    }
}

