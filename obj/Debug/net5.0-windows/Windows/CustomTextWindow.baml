   M S B A M L   `   `   `  ����S  OKeyboard Speed Simulator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:KeyboardSpeedSimulatorKeyboardSpeedSimulator  5   	   -    'KeyboardSpeedSimulator.CustomTextWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:KeyboardSpeedSimulator     5   	     � Title$  Custom Texts��5   	   $	��450��6   $	��600��6+    � 
ResizeMode$ NoResize=�67   .��5	      �  � RowDefinitions 5
   
   �� 5      $��* �6   �� 5      $��0.15* �6   .+�5   
   �� -   5         ��Name$ TextsListViewer��5       �� DisplayMemberPath$
 Name��6,   $��25(�6E   ��5      �� 5       �� 
TargetType" ��6   .�5      -   5        5      5      �� 5   
   -   5         ��Name$ 
OpenButton��5      $��1��6%   $
��Left=�62   $��10, 0, 0, 0q�6M   $��Center=�6b      ButtonStyle1#���   6}   $��Select Text��6�   6�   �� 5   
   -   5        $ 	AddButton��5      $��1��6$   $��Center=�61   $��Center=�6O   #���   6j   $��Add Text��6�   6�   �� 5   
   -   5        $ RemoveButton��5      $��1��6'   $��Right=�64   $��0, 0, 10, 0q�6P   $��Center=�6f   #���   6�   $��Remove Text��6�   6�   5      5      