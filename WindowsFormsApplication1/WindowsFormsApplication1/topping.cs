using System;
using System.Collections;

namespace Jiro{
    

    class Topping {
        
        private Volume garlic { get; set; }     //ニンニク
        private Volume vegetable { get; set; }  //ヤサイ
        private Volume oil { get; set; }        //アブラ
        private Volume sauce { get; set; }      //カラメ
        public string jiroCall { get; set; }    //コール
        
        const string TOPPING_GARLIC = "ニンニク";
        const string TOPPING_VEGETABLE = "ヤサイ";
        const string TOPPING_OIL = "アブラ";
        const string TOPPING_SAUCE = "カラメ";
        
        public enum Volume
        {
            NUKI,           //抜き
            SUKUNAME,       //スクナメ
            DEFAULT,        //デフォルト値
            MASHI,          //マシ
            MASHIMASHI,     //マシマシ
            CHOMOLUNGMA     //チョモランマ
        }
        
        /** コンストラクタ
        *  二郎コールで初期化します。
        */
        public Topping (string call){
            
            garlic = Volume.DEFAULT;
            oil = Volume.DEFAULT;
            vegetable = Volume.DEFAULT;
            sauce = Volume.DEFAULT;
            jiroCall = call;
            
            if(call.Length == 0){
                jiroCall = "コールなし";
                return;
            }
            
            ArrayList tmpPosArray = new ArrayList();
            string[] chkArr = {TOPPING_GARLIC,TOPPING_OIL,TOPPING_VEGETABLE,TOPPING_SAUCE };
            foreach (string element in chkArr)
            {
                if (0 <= call.IndexOf(element)){
                    tmpPosArray.Add(call.IndexOf(element));
                }
            }
            
            if(tmpPosArray.Count == 0){
                throw new System.ArgumentException("コールではないことを言ってないか？", "call");
            }
            
            IComparer myComparer = new myReverserClass();
            tmpPosArray.Sort( myComparer );
                            
            string tmpJiroCall = call;
            ArrayList tmpCallArray = new ArrayList();

            foreach(int position in tmpPosArray){
                string tmpObject = tmpJiroCall.Substring(position);
                tmpCallArray.Add(tmpObject);
                tmpJiroCall = tmpJiroCall.Replace(tmpObject,"");
            }
            
            foreach(string topping in tmpCallArray){
                if(specifyToppingCategory(topping,TOPPING_GARLIC)){
                    garlic = specifyToppingAmount(topping,TOPPING_GARLIC);
                }else if(specifyToppingCategory(topping,TOPPING_OIL)){
                    oil = specifyToppingAmount(topping,TOPPING_OIL);
                }else if(specifyToppingCategory(topping,TOPPING_SAUCE)){
                    sauce = specifyToppingAmount(topping,TOPPING_SAUCE);
                }else if(specifyToppingCategory(topping,TOPPING_VEGETABLE)){
                    vegetable = specifyToppingAmount(topping,TOPPING_VEGETABLE);
                }
            }
        }
        
        /** コールの要素が指定されたものであるかを判定します */
        public bool specifyToppingCategory(string call,string topping){
            if (0 <= call.IndexOf(topping)){
                return true;
            }else{
                return false;
            }
        }
        
        /**
         * 指定した要素の量を返します
         * @param コールの一部
         * @param トッピングの種類
         * @return Volume
         */
        public Volume specifyToppingAmount(string call,string topping){
            string tmpCall = call.Replace(topping,"");
            switch(tmpCall){
                case "抜き":
                    return Volume.NUKI;
                    break;
                case "スクナメ":
                    return Volume.SUKUNAME;
                    break;
                case "":
                    return Volume.DEFAULT;
                    break;
                case "マシ":
                    return Volume.MASHI;
                    break;
                case "マシマシ":
                    return Volume.MASHIMASHI;
                    break;
                case "チョモランマ":
                    return Volume.CHOMOLUNGMA;
                    break;
                default:
                    throw new System.ArgumentException(topping+"の部分が怪しかったぞ。", "call");
                    break;
            }
        }
        
        /**
         * Volumeの情報を日本語に変換します
         * @param callAmount Volume情報
         * @return 量の日本語
         */
        public static string convertToJapanese(Volume callAmount){
            switch(callAmount){
                case Volume.NUKI:
                    return "抜き";
                    break;
                case Volume.SUKUNAME:
                    return "スクナメ";
                    break;
                case Volume.DEFAULT:
                    return "デフォルト";
                    break;
                case Volume.MASHI:
                    return "マシ";
                    break;
                case Volume.MASHIMASHI:
                    return "マシマシ";
                    break;
                case Volume.CHOMOLUNGMA:
                    return "チョモランマ";
                    break;
                default:
                    return "";
                    break;
            }
        }

        /**
         * トッピングの情報をコンソールに出力します。
         */
        public void outputToppingInfo(){
            Console.WriteLine("【"+ jiroCall +"】");
            Console.WriteLine("ニンニク："+convertToJapanese(garlic));
            Console.WriteLine("アブラ："+convertToJapanese(oil));
            Console.WriteLine("ヤサイ："+convertToJapanese(vegetable));
            Console.WriteLine("カラメ："+convertToJapanese(sauce));
        }
    }


    /**
     * 降順ソートを行うのに使用するクラス
     */
    public class myReverserClass : IComparer  {
        int IComparer.Compare( Object x, Object y )  {
            return( (new CaseInsensitiveComparer()).Compare( y, x ) );
        }
    }
   
}