   M S B A M L   `   `   `  ����   Keyboard Speed Simulator'    !KeyboardSpeedSimulator.MainWindow   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006       � Title$  Keyboard Speed Simulator�� � WindowState$ 	Maximized=� � 
ResizeMode$ CanResizeWithGrip=�.���  � ColumnDefinitions �� �� ��  � RowDefinitions �� $	��30* ��� $	��30* ��� $	��50* ��� $
��130* ��� $	��30* �.+��� $��0��$��0��$��20(�$��Right=� �� TextAlignment$ Center=��� -    ��Name$ CharsPerMinLabel��$�0 chars/min���� �� -   $ BestCharsPerMinLabel��$�0 chars/min��$��15(�
��������� $��1��$��0��$��20(�$��Center=�$ Center=��� -   $ WordsPerMinLabel��$�0 words/min���� �� -   $ BestWordsPerMinLabel��$�0 words/min��$��15(�
��������� $��2��$��0��$��20(�$
��Left=�$ Center=��� -   $ MisPerLineLabel��$�
0 mis/line���� �� -   $ BestMisPerLineLabel��$�
0 mis/line��$��15(�
��������� -    ��Name$ MainTextBox��$��3��$��1��$��Bottom=�$��Center=�$��30(�$��	80,0,80,0q��� $��2��$��3��$��	80,0,80,0q�$��30(�$	��Top=��� -   $ FirstStringLabel���� �� -	   $ SecondStringLabel���� �� -
   $ ThirdStringLabel���� -    ��Name$ AutoBcspCheckBox��$��Auto BackSpace��$��3��$��Bottom=�$��13(����	#FF838383$��2q�$��10, 0, 0, 50q�	 � LayoutTransform	 �� 
 �� ScaleX$	
 1.6Q� �� ScaleY$	 1.6Q��� -    ��Name$ RusImage��$��3��$��3��$��200, 0, 200, 0q�$��Photo/KlavaPhotoRus.png��$��Center=��� -   $ EngImage��$��3��$��3��$��200, 0, 200, 0q�$��Photo/KlavaPhotoEng.png��$��Center=�$y�	Collapsed=��� -    ��Name$ ChangeLangButton��   ButtonStyle1#���   $��2��$��3��$	��Eng��$��20(�$��Bottom=�$��Right=�$��50q��� -   $ HideKeybButton��#���   $��2��$��3��$
��Hide��$��20(�$��Bottom=�$��Right=�$��
0,0,115,50q��� -   #���   $��0��$��4��$��Custom text��$��Center=�$��Right=��� -   #���   $��1��$��4��$��New text��$��Center=�$��Center=��� -   #���   $��2��$��4��$��
Statistics��$��Center=�$
��Left=�