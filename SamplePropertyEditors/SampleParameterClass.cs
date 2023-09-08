using SamplePropertyEditors.CustomPropertyEditor;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Windows.Input;
using System.Windows.Media;
using YukkuriMovieMaker.Commons;
using YukkuriMovieMaker.Controls;

namespace SamplePropertyEditors
{
    /*
     * アイテム編集エリアに編集項目を追加するためには[Display]属性と[AnimationSlider]等のアイテム編集コントロール属性の2つが必要です。
     * このクラスでは、YMM4に初期搭載されているアイテム編集コントロールの一覧を示します。
     */
    public class SampleParameterClass : Animatable
    {
        /// <summary>
        /// アニメーションスライダー
        /// 直線移動等のアニメーションを設定するためのコントロールです。
        /// </summary>
        [Display(GroupName = "グループ名", Name = "アニメーション", Description = "項目の説明")]
        [AnimationSlider("F0", "%", 0, 100)]
        public Animation Animation { get; } = new Animation(100, 0, 100);

        /// <summary>
        /// 数値スライダー
        /// アニメーションしない数値を設定するためのコントロールです。
        /// [DefaultValue]を設定すると、テキストボックスに空白を入力したときにデフォルト値が設定されます。
        /// [Range]を設定すると、数値の範囲を制限できます。
        /// </summary>
        [Display(GroupName = "グループ名", Name = "数値", Description = "項目の説明")]
        [TextBoxSlider("F1", "%", 0, 100)]
        [DefaultValue(0d)]
        [Range(0,100)]
        public double DoubleValue { get => doubleValue; set => Set(ref doubleValue, value); }
        double doubleValue = 0;

        /// <summary>
        /// 色選択コントロール
        /// </summary>
        [Display(GroupName = "グループ名", Name = "色", Description = "項目の説明")]
        [ColorPicker]
        public Color Color { get => color; set => Set(ref color, value); }
        Color color = Colors.White;

        /// <summary>
        /// フォルダ選択コントロール
        /// </summary>
        [Display(GroupName = "グループ名", Name = "フォルダ", Description = "項目の説明")]
        [DirectorySelector]
        public string Directory { get => directory; set => Set(ref directory, value); }
        string directory = "";

        /// <summary>
        /// ファイル選択コントロール
        /// </summary>
        [Display(GroupName = "グループ名", Name = "ファイル", Description = "項目の説明")]
        [FileSelector(YukkuriMovieMaker.Settings.FileGroupType.ImageItem)]
        public string File { get => file; set => Set(ref file, value); }
        string file = "";

        /// <summary>
        /// enum選択コントロール
        /// </summary>
        [Display(GroupName = "グループ名", Name = "列挙型", Description = "項目の説明")]
        [EnumComboBox]
        public SampleEnum Enum { get => sampleEnum; set => Set(ref sampleEnum, value); }
        SampleEnum sampleEnum = SampleEnum.A;

        /// <summary>
        /// フォント選択コントロール
        /// </summary>
        [Display(GroupName = "グループ名", Name = "フォント", Description = "項目の説明")]
        [FontComboBox]
        public string Font { get => font; set => Set(ref font, value); }
        string font = "メイリオ";

        /*
        /// <summary>
        /// キーボードショートカットコントロール
        /// </summary>
        [Display(GroupName = "グループ名", Name = "ショートカット", Description = "項目の説明")]
        [KeyGestureEditorAttribute]
        public KeyGesture KeyGesture { get => keyGesture; set => Set(ref keyGesture, value); }
        KeyGesture keyGesture = new KeyGesture(Key.None);
        */

        /// <summary>
        /// テキスト編集コントロール
        /// </summary>
        [Display(GroupName = "グループ名", Name = "テキスト", Description = "項目の説明")]
        [TextEditor(AcceptsReturn = true)]
        public string Text { get => text; set => Set(ref text, value); }
        string text = string.Empty;

        /// <summary>
        /// bool値をトグルするコントロール
        /// </summary>
        [Display(GroupName = "グループ名", Name = "トグル", Description = "項目の説明")]
        [ToggleSlider]
        public bool Toggle { get => toggle; set => Set(ref toggle, value); }
        bool toggle = false;

        /// <summary>
        /// AutoGenerateFieldをtrueにすると、子クラスのプロパティもアイテム編集エリアに表示されます。
        /// </summary>
        [Display(GroupName = "グループ名", AutoGenerateField = true)]
        public InnerClass Inner { get => inner; set => Set(ref inner, value); }
        InnerClass inner = new ();

        /// <summary>
        /// YMM4に初期搭載されているコントロール以外を使用する場合、
        /// - IPropertyEditorControlを実装したコントロール
        /// - PropertyEditorAttributeを継承したアイテム編集コントロール属性
        /// の2つを実装する必要があります。
        /// 
        /// IncreaseDecreaseButtonは、数値を増減させるボタンを表示するカスタムコントロールのサンプルです。
        /// </summary>
        [Display(GroupName = "グループ名", Name = "カスタムコントロール", Description = "項目の説明")]
        [IncreaseDecreaseButton]
        public int IntValue { get => intValue; set => Set(ref intValue, value); }
        int intValue = 0;

        protected override IEnumerable<IAnimatable> GetAnimatables() => new IAnimatable[] { Animation, Inner };
    }
    public class InnerClass : Animatable
    {
        [Display(Name = "アニメーション", Description = "項目の説明")]
        [AnimationSlider("F0", "%", 0, 100)]
        public Animation Child1 { get; } = new Animation(100, 0, 100);

        [Display(Name = "アニメーション", Description = "項目の説明")]
        [AnimationSlider("F0", "%", 0, 100)]
        public Animation Child2 { get; } = new Animation(100, 0, 100);

        protected override IEnumerable<IAnimatable> GetAnimatables() => new[] { Child1, Child2 };
    }
}