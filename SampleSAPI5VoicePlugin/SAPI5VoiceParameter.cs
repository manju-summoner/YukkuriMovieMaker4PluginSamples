﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using YukkuriMovieMaker.Plugin.Voice;
using YukkuriMovieMaker.UndoRedo;
using YukkuriMovieMaker.Controls;

namespace SampleSAPI5VoicePlugin
{
    internal class SAPI5VoiceParameter : VoiceParameterBase
    {
        double speed = 0;

        [Display(Name = "話速", Description ="テキストの読み上げ速度")]
        [Range(-10,10)]
        [DefaultValue(0)]
        [TextBoxSlider("F0", "", -10, 10, Delay = -1)]//Delayを-1にするとスライダーを操作し終えるまで反映しない。これがないとスライダーの操作中に音声の再生成処理が走ってしまう。
        public double Speed { get => speed;set=>Set(ref speed, value); }
    }
}