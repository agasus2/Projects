   M S B A M L   `   `   `  ����F  BElectronika, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Electronika.ViewsElectronika.Views  5   	   ?$clr-namespace:Electronika.ViewModelsElectronika.ViewModels  5   	   ?$clr-namespace:Electronika.ConvertersElectronika.Converters  5   	   "    Electronika.Views.LeaderBord   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:Electronika.Views     5   	   3vm$clr-namespace:Electronika.ViewModels     5   	   2c$clr-namespace:Electronika.Converters     5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5	   	     � Title$  
LeaderBord��5   	   $	��450��6   $	��400��6)    � WindowStartupLocation$ CenterScreen=�65    � WindowStyle$
 None=�6[    � 
ResizeMode$ NoResize=�6n    � 	Resources 5      .   (Electronika.Converters.RowIndexConverter   rownumberconverter �� 
TargetType �� Property �� Value��%n   &	        '��        5   
   6;   �� 5   
   " ��6   .�5      ��  � ��$ 5q�6'   5      5      .  (System.Windows.Interactivity.Interaction   Triggers 5      /  )System.Windows.Interactivity.EventTrigger  5   
   	   	EventName$	 Loaded��6   .  (System.Windows.Interactivity.TriggerBase
   Actions.
 5      6  0System.Windows.Interactivity.InvokeCommandAction     Command 6$   �� *LoadedCommand+   CommandParameter 6F   �� 5      .��5      �  � RowDefinitions 5   
   �� 5      $��7* �6   �� 5      $��* �6   .+�5   
   (� $��0��6   $	��Top=�6   $
��Left=�67    (� Stretch$
 Fill=�6R   .��5!      �� 
����ح� J� IsHitTestVisible .  ��6F   �� *Scores+ �� AlternationCount 6e   �� *Scores.Count+��5"      �� 5#      .R�5$      ��  �� Orientation$ 
Horizontal=�6%   .+�5%      �� ��6(   ��  �� RelativeSource �� *FindAncestor+ �� AncestorType" �� �� 	Converter# [   �� UpdateSourceTrigger$ PropertyChanged=��� 5&      ��6(   ��  �� Path$ 
LeaderName��� 5'      ��6(   �� $ LeaderScore�5(      5)      5+      5-      (� 5/   
   $��1��6   $��Bottom=�6   $��Center=�6:   .��50      �� $��OK��6   $��47��6A   ��6#   �� *	OKCommand+6A   51      54      55      