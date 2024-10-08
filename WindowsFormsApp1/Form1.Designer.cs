﻿using System.Drawing;
using System;

namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.textBox_dx = new System.Windows.Forms.TextBox();
            this.textBox_dy = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button11 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.button10 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pictureBox1.Location = new System.Drawing.Point(14, 15);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(608, 688);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(658, 668);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(150, 35);
            this.button1.TabIndex = 2;
            this.button1.Text = "Очистка";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.clearButton);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(655, 19);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(169, 50);
            this.button2.TabIndex = 3;
            this.button2.Text = "Добавить точку";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.createPoint);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(655, 76);
            this.button3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(174, 56);
            this.button3.TabIndex = 4;
            this.button3.Text = "Добавить ребро";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.createEdge);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(655, 140);
            this.button4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(174, 54);
            this.button4.TabIndex = 5;
            this.button4.Text = "Создать полигон";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.createPolygon);
            // 
            // textBox_dx
            // 
            this.textBox_dx.Location = new System.Drawing.Point(903, 19);
            this.textBox_dx.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox_dx.Name = "textBox_dx";
            this.textBox_dx.Size = new System.Drawing.Size(112, 26);
            this.textBox_dx.TabIndex = 6;
            // 
            // textBox_dy
            // 
            this.textBox_dy.Location = new System.Drawing.Point(903, 54);
            this.textBox_dy.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox_dy.Name = "textBox_dy";
            this.textBox_dy.Size = new System.Drawing.Size(112, 26);
            this.textBox_dy.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(871, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "dx:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(871, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "dy:";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(874, 96);
            this.button5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(147, 60);
            this.button5.TabIndex = 10;
            this.button5.Text = "Смещение на dx dy";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.shiftXY);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(655, 259);
            this.button6.Margin = new System.Windows.Forms.Padding(2);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(188, 52);
            this.button6.TabIndex = 11;
            this.button6.Text = "Поворот вокруг центра";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.turnAroundCenter);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(865, 259);
            this.button7.Margin = new System.Windows.Forms.Padding(2);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(188, 52);
            this.button7.TabIndex = 12;
            this.button7.Text = "Поворот вокруг точки";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.turnAroundPoint);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(732, 224);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(111, 26);
            this.textBox1.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(668, 225);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 20);
            this.label3.TabIndex = 14;
            this.label3.Text = "Угол";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(680, 341);
            this.textBox2.Margin = new System.Windows.Forms.Padding(2);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(145, 26);
            this.textBox2.TabIndex = 15;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(903, 339);
            this.textBox3.Margin = new System.Windows.Forms.Padding(2);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(145, 26);
            this.textBox3.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(654, 341);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 20);
            this.label4.TabIndex = 17;
            this.label4.Text = "X";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(871, 344);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(20, 20);
            this.label5.TabIndex = 18;
            this.label5.Text = "Y";
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(658, 380);
            this.button8.Margin = new System.Windows.Forms.Padding(2);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(258, 68);
            this.button8.TabIndex = 19;
            this.button8.Text = "Масштабирование отн. центра";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.scaleCenter);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(929, 380);
            this.button9.Margin = new System.Windows.Forms.Padding(2);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(252, 68);
            this.button9.TabIndex = 20;
            this.button9.Text = "Масштабирование отн. точки";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.scalePoint);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(852, 168);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(217, 28);
            this.comboBox1.TabIndex = 21;
            this.comboBox1.Text = "Выбрать полигон";
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(658, 454);
            this.button11.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(258, 52);
            this.button11.TabIndex = 23;
            this.button11.Text = "Проверка принадлежности точки полигону";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(934, 458);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 32);
            this.label6.TabIndex = 24;
            this.label6.Text = "false";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(658, 543);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(258, 28);
            this.comboBox2.TabIndex = 25;
            this.comboBox2.Text = "Выбрать ребро";
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(929, 543);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(252, 55);
            this.button10.TabIndex = 26;
            this.button10.Text = "Поиск точки пересечения двух ребер";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(929, 604);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(252, 71);
            this.button12.TabIndex = 27;
            this.button12.Text = "Классифицировать положение точки относительно ребра";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1367, 729);
            this.Controls.Add(this.button12);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_dy);
            this.Controls.Add(this.textBox_dx);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox textBox_dx;
        private System.Windows.Forms.TextBox textBox_dy;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button12;
    }
}

