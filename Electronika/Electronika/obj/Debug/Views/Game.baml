   M S B A M L   `   `   `  ����F  BElectronika, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Electronika.ViewsElectronika.Views  5   	   ?$clr-namespace:Electronika.ViewModelsElectronika.ViewModels  5   	       Electronika.Views.Game   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:Electronika.Views     5   	   3vm$clr-namespace:Electronika.ViewModels     5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	     � Title$  
MainWindow��5
   	   $	��412��6   $	��674��6*   $	��412��66   $	��674��6F    � WindowStartupLocation$ CenterScreen=�5   	    � WindowStyle$
 None=�6.    � 
ResizeMode$ NoResize=�6A   .  (System.Windows.Interactivity.Interaction   Triggers 5      /  )System.Windows.Interactivity.EventTrigger  5   
      	EventName$ Closing��6   .  (System.Windows.Interactivity.TriggerBase   Actions. 5      6  0System.Windows.Interactivity.InvokeCommandAction     Command 6$   �� *WindowsClosing+   CommandParameter 6G   �� 5        5   
   $ Loaded��6   . 5         6$   �� *LoadedCommand+ 6F   �� 5      	 � 	Resources	 5      
 �� 
TargetType �� Property �� Value��%T   '��       �� 5   
   "
 ��6   .�5      ��  � ��$
 Fill=�6(   5      5       J� InputBindings 5      �� 5   
   
 �� Key 6   �� *LTKey+ �� Command 6+   �� *	LTCommand+�� 5   
    6   �� *LBKey+ 6+   �� *	LBCommand+�� 5   
    6   �� *RTKey+ 6+   �� *	RTCommand+�� 5   
    6   �� *RBKey+ 6+   �� *	RBCommand+.��5!      �  � RowDefinitions 5"   
   �� 5#      $��* �6   �� 5$      $	��10* �6   �� 5%      $��50 �6    � ColumnDefinitions 5'   
   �� 5(      $
��Auto �6   �� 5)      $��* �6   �� 5*      $
��Auto �6   .+�5-   
   (� $��0��6   $��3��6   $	��100��63   .��5.      �� $��Electronika��6   $��Stretch=�6+   $��Bottom=�6I   5/      � 50   
   $��0��6   $��0��6   $��3��6,    51      �� 52      $��* �6    �� 53      $��* �6    �� 54      $��* �6    �� 55      $��* �6    �� 56      $��* �6    .+�59      (�  (� Stretch$
 Fill=�6   $��2��6&   $��5q�63   .��5:      �� $��LT��6   $��Bottom=�6F   $��30��6a   ��6'   �� *	LTCommand+6a   5;      (� 5<      $
 Fill=�6   $��4��6&   $��5q�63   .��5=      �� $��LB��6   $��Bottom=�6F   $��30��6b   ��6'   �� *	LBCommand+6b   5>      5?      � 5@   
   $��0��6   $��2��6   $��3��6,    5A      �� 5B      $��* �6    �� 5C      $��* �6    �� 5D      $��* �6    �� 5E      $��* �6    �� 5F      $��* �6    .+�5I      (� $
 Fill=�6   $��2��6&   $��5q�63   .��5J      �� $��RT��6   $��Bottom=�6F   $��30��6b   ��6'   �� *	RTCommand+6b   5K      (� 5L      $
 Fill=�6   $��4��6&   $��5q�63   .��5M      �� $��RB��6   $��Bottom=�6F   $��30��6b   ��6'   �� *	RBCommand+6b   5N      5P      (� 5S   
   $��0��6   $��2��6    $��5q�61   $��Center=�6<   $��Right=�6W   .��5T      �� $��Х��6   $��25��6B   $��57��6Q   ��6!   �� *CloseCommand+6Q   5U      � 5V   
   $��1��6   $��1��6    5W      �� 5X      $��5* �6#   �� 5Y      $��* �6#   �� 5Z      $��5* �6#    5\      �� 5]      $��* �6    �� 5^      $��5* �6    .+�5`      � -   5         �Name$ MainGrid��5`      $��2��6&   $��3��67   .+�5a      �� ��6   �� *
Background+�� 5b      $��Bottom=�6q   ��6   �� *CurrentWolf.WolfSource+y�6>   �� *CurrentWolf.WolfVisibility+6q   �� 5d      $��Bottom=�6]   ��6   �� *Hp.HP1Source+y�65   �� *Hp.Hp1Visibility+6]   �� 5e      $��Bottom=�6]   ��6   �� *Hp.HP2Source+y�65   �� *Hp.Hp2Visibility+6]   �� 5f      $��Bottom=�6]   ��6   �� *Hp.HP3Source+y�65   �� *Hp.Hp3Visibility+6]   5h      (� 5i      $��Center=�6   $	��Top=�63   $��1��6K   .��5j      �� $��Center=�6:   $	��Top=�6X   ��6   �� *CurrentScore+6X   5k      5l      5m      5n      