   M S B A M L   `   `   `  ����F  BElectronika, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Electronika.ViewsElectronika.Views  5   	   ?$clr-namespace:Electronika.ViewModelsElectronika.ViewModels  5   	       Electronika.Views.Menu   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:Electronika.Views     5   	   3vm$clr-namespace:Electronika.ViewModels     5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	     � Title$
  Menu��5
   	   $	��290��6   $	��800��6#    � WindowStartupLocation$ CenterScreen=�6/    � WindowStyle$
 None=�6T    � 
ResizeMode$ NoResize=�6g   .  (System.Windows.Interactivity.Interaction   Triggers 5      /  )System.Windows.Interactivity.EventTrigger  5   
      	EventName$ 	Activated��6   .  (System.Windows.Interactivity.TriggerBase   Actions. 5      6  0System.Windows.Interactivity.InvokeCommandAction     Command 6$   �� *LoadedAndActivatedCommand+   CommandParameter 6R   �� 5        5   
   $ Loaded��6   . 5         6$   �� *LoadedAndActivatedCommand+ 6R   �� 5      .��5      � 	 � ColumnDefinitions	 5   
   �� 5      $��* �6   �� 5      $��2* �6   �� 5      $��* �6   
 � RowDefinitions
 5   
   �� 5      $��* �6   �� 5      $��2* �6   �� 5       $��* �6   .+�5"   
   (� $��0��6   $��3��6   $	��100��63   .��5#      �� $��Electronika��6   $��Stretch=�6+   $��Bottom=�6I   5$      � 5%   
   $��3��6   $��0��6    .+�5&      �� $
��Fill=�66   ��6   �� *
LeftWolf+66   �� 5'      $
��Fill=�66   ��6   �� *	LeftEgg+66   5(      � 5)   
   $��3��6   $��2��6    .+�5*      �� $
��Fill=�63   ��6   �� *	RightWolf+63   �� 5+      $
��Fill=�62   ��6   �� *
RightEgg+62   5,      (� 5-   
   $��1��6   $��Center=�6"   $��1��6=   $��2��6J   .��5.   
   �� $��25q�6   .+�5/      �� $��5q�6   $��Center=�6%   $	��200��6E   $��FunWithMVVM.Menu��6u   ��6U   �� *PlayCommand+.��50      �� $
��Play��6   51      �� 52      $��5q�6   $��Center=�6    $	��200��6?   ��6N   �� *LeaderBordCommand+.��53      �� $��Leader board��6   54      �� 55      $��5q�6   $��Center=�6!   $	��200��6@   ��6P   �� *SettingsCommand+.��56      �� $��Settings��6   57      �� 58      $��5q�6   $��Center=�6$   $	��200��6C   ��6R   �� *AboutCommand+.��59      �� $��About��6    5:      �� 5;      $��5q�6   $��Center=�6!   $	��200��6`   ��6@   �� *ExitCommand+.��5<      �� $
��Exit��6   5=      5>      5?      5@      5A      