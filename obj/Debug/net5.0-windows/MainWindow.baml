   M S B A M L   `   `   `  ����  Keyboard Speed Simulator'    !KeyboardSpeedSimulator.MainWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	     � Title$  Keyboard Speed Simulator��5   	    � WindowState$ 	Maximized=�6*    � 
ResizeMode$ CanResizeWithGrip=�6B   .��5      �  � ColumnDefinitions 5	   
   �� 5
      �� 5      �� 5       � RowDefinitions 5   
   �� 5      $	��30* �6   �� 5      $	��30* �6   �� 5      $	��50* �6   �� 5      $
��130* �6   �� 5      $	��30* �6   .+�5   
   �� $��0��6   $��0��6$   $��20(�61   $��Right=�6?    �� TextAlignment$ Center=�6[   �� 5      -   5         ��Name$ CharsPerMinLabel��5      $�0 chars/min��6,   �� 5      �� 5      -   5        $ BestCharsPerMinLabel��5      $�0 chars/min��60   $��15(�6C   
�������6Q   5      �� 5   
   $��1��6   $��0��6$   $��20(�61   $��Center=�6?   $ Center=�6\   �� 5      -   5        $ WordsPerMinLabel��5      $�0 words/min��6,   �� 5      �� 5      -   5        $ BestWordsPerMinLabel��5      $�0 words/min��60   $��15(�6C   
�������6Q   5      �� 5!   
   $��2��6   $��0��6$   $��20(�61   $
��Left=�6?   $ Center=�6Z   �� 5"      -   5        $ MisPerLineLabel��5"      $�
0 mis/line��6+   �� 5#      �� 5$      -   5        $ BestMisPerLineLabel��5$      $�
0 mis/line��6/   $��15(�6A   
�������6O   5%      �� 5'   
   -   5         ��Name$ MainTextBox��5'   3   $��3��6   $��1��6&   $��Bottom=�6H   $��Center=�5(      $��30(�6-   $��	80,0,80,0q�6;   6N   �� 5*   
   $��2��6   $��3��6!   $��	80,0,80,0q�65   $��30(�6H   $	��Top=�6V   �� 5+      -   5        $ FirstStringLabel��5+      �� 5,      �� 5-      -	   5        $ SecondStringLabel��5-      �� 5.      �� 5/      -
   5        $ ThirdStringLabel��5/      50      �� 52   
   -   5         ��Name$ AutoBcspCheckBox��52      $��Auto BackSpace��6-   $��3��6F   $��Bottom=�6S   $��13(�6n   ���	#FF838383$��2q�53   +   $��10, 0, 0, 50q�6?   	 � LayoutTransform	 55      �� 56      
 �� ScaleX$	
 1.6Q�6!    �� ScaleY$	 1.6Q�6.   58      �� 5:   
   -   5         ��Name$ RusImage��5:      $��3��6"   $��3��6/   $��200, 0, 200, 0q�6C   $��Photo/KlavaPhotoRus.png��6[   $��Center=�5;      �� 5<   
   -   5        $ EngImage��5<      $��3��6"   $��3��6/   $��200, 0, 200, 0q�6C   $��Photo/KlavaPhotoEng.png��6[   $��Center=�5=      $y�	Collapsed=�6+   �� 5?   
   -   5         ��Name$ ChangeLangButton��5@   T      ButtonStyle1#���   5?      $��2��68   $��3��6H   $	��Eng��6U   $��20(�6c   $��Bottom=�5@      $��Right=�6,   $��50q�6H   5A      �� 5B   
   -   5        $ HideKeybButton��5C   \   #���   5B      $��2��68   $��3��6H   $
��Hide��6U   $��20(�6d   $��Bottom=�5C      $��Right=�6,   $��
0,0,115,50q�6H   5D      �� 5F   
   -   5        #���   5F      $��0��69   $��4��6I   $��Custom text��6V   $��Center=�5G      $��Right=�6,   6H   �� 5H   
   -   5        #���   5H      $��1��68   $��4��6H   $��New text��6U   $��Center=�5I      $��Center=�6,   6I   �� 5J   
   -   5        #���   5J      $��2��68   $��4��6H   $��
Statistics��6U   $��Center=�5K      $
��Left=�6,   6G   5L      5M      