using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApplication1;

namespace Jiro {
    public partial class Form1 :Form {
        staff MrTaka;
        Noodle product;
        Topping topping;

        public Form1() {
            InitializeComponent();
            label2.Text = "";
            MrTaka = new staff();
        }

        private void button1_Click(object sender, EventArgs e) {
            product = MrTaka.cooking(Gram.SYOU);
            label2.Text = "ニンニクいれますか";
        }
        private void button2_Click(object sender, EventArgs e) {
            product = MrTaka.cooking(Gram.DEFAULT);
            label2.Text = "ニンニクいれますか";
        }
        private void button3_Click(object sender, EventArgs e) {
            product = MrTaka.cooking(Gram.DAI);
            label2.Text = "ニンニクいれますか";
        }
        private void button4_Click(object sender, EventArgs e) {
            label2.Text = textBox1.Text;
            try {
                topping = MrTaka.toppingMake(textBox1.Text);
                string tx = "【" + j(product.NoodleVolume) + "おまたせ！】\n"
                    + "ニンニク:" + j(topping.garlic) + "\n"
                    + "アブラ:" + j(topping.oil) + "\n"
                    + "ヤサイ:" + j(topping.vegetable) + "\n"
                    + "カラメ:" + j(topping.sauce);
                label3.Text = tx;
            } catch(Exception exc) {
                label2.Text = exc.ToString();
            }
        }
        private string j(Topping.Volume v) {
            switch(v) {
                case Topping.Volume.CHOMOLUNGMA:
                    return "チョモランマ";
                case Topping.Volume.DEFAULT:
                    return "デフォルト";
                case Topping.Volume.MASHI:
                    return "マシ";
                case Topping.Volume.MASHIMASHI:
                    return "マシマシ";
                case Topping.Volume.NUKI:
                    return "抜き";
                case Topping.Volume.SUKUNAME:
                    return "スクナメ";
                default:
                    return "指定なし";
            }
        }
        private string j(Gram v) {
            switch(v) {
                case Gram.SYOU:
                    return "小ラーメン";
                case Gram.DAI:
                    return "大ラーメン";
                case Gram.DEFAULT:
                    return "ラーメン";
                default:
                    return "指定なし";
            }
        }
    }
}
