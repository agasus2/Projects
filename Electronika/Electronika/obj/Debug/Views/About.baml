   M S B A M L   `   `   `  ����F  BElectronika, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Electronika.ViewsElectronika.Views  5   	   ?$clr-namespace:Electronika.ViewModelsElectronika.ViewModels  5   	       Electronika.Views.About   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:Electronika.Views     5   	   3vm$clr-namespace:Electronika.ViewModels     5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	     � Title$  About��5
   	   $	��450��6   $	��800��6$    � WindowStartupLocation$ CenterScreen=�60    � 
ResizeMode$ NoResize=�6U    � WindowStyle$
 None=�6k   .  (System.Windows.Interactivity.Interaction   Triggers 5      /  )System.Windows.Interactivity.EventTrigger  5   
      	EventName$ Loaded��6   .  (System.Windows.Interactivity.TriggerBase   Actions. 5      6  0System.Windows.Interactivity.InvokeCommandAction     Command 6$   �� *LoadedCommand+   CommandParameter 6F   �� 5      .��5      � 	 � ColumnDefinitions	 5   
   �� 5      $��* �6   �� 5      $��2* �6   .+�5   
   �� $��0��6   $
��Fill=�6<   ��6    �� *
LeftWolf+6<   � 5   
   $��1��6   
 � RowDefinitions
 5      �� 5      $��* �6    �� 5      $
��1.5* �6    .+�5      (� $
��Left=�6   .��5      �� .+�5      �� $!�� Product Name : Electronika��6    �� 5       $�� Version : 0.1��6    �� 5!      $!�� Created by : Maxym Aharkov��6    �� 5"      $�� Company Name : DbBest��6    5#      5$      � 5%      $��1��6   	 5&      �� 5'      $��5* �6'   �� 5(      $��* �6'   
 5*      �� 5+      $��5* �6$   �� 5,      $��* �6$   .+�5.      (� $��2��6    (� Stretch$
 Fill=�6/   .��5/      ��  �� 
IsReadOnly . ��6/   �� *Description+50      (� 51      $��1��6   $��1��6'   $��Bottom=�68   $��Right=�6S   .��52      �� $��OK��6   $��41��6+   ��66   �� *	OKCommand+54      55      56      57      58      