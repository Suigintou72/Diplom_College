   M S B A M L   `   `   `  ���� A  =Diplom, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:Diplom.Games.TetrisDiplom.Games.Tetris  $    Diplom.Games.Tetris.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     3local!clr-namespace:Diplom.Games.Tetris     $	��481��$	��479��$
��Left=�$	��Top=�  � 
ResizeMode$  CanMinimize=����	#FFCBCACA � WindowStyle$ ThreeDBorderWindow=� � Icon$. (/Diplom;component/Interface/cubesiki.ico�� � Title$ Тетрис��.��� -    �Name$
 grid��$��0,0,0,1q�.+�� -   $ 
tetrisGrid��$��	28,17,0,0q� K� ZIndex$ 2��$	��400��$	��250��$
��Left=�$	��Top=�
���   � � RowDefinitions �� $��25 ��� $��25 ��� $��25 ��� $��25 ��� $��25 ��� $��25 ��� $��25 ��� $��25 ��� $��25 ��� $��25 ��� $��25 � � ToolTip$  ���� $��25 ��� $��25 ��� $��25 ��� $��25 ��� $��25 � � ColumnDefinitions �� $��25 ��� $��25 ��� $��25 ��� $��25 ��� $��25 ��� $��25 �$  ���� $��25 ��� $��25 ��� $��25 ��� $��25 ��� -   	 ��Name$	 startStopBtn��$��Начать игру��$
��Left=�$��321,367,0,0q�$	��Top=�$	��106��$��50��$��14(�#��� ��$
��Bold"��� -   
 ��Name$

 back��$
��Left=�$	��405��$��	26,15,0,0q�$	��Top=�$	��254��
��������� -    ��Name$ nextShapeCanvas��$
��Left=�$��75��$��328,132,0,0q�$	��Top=�$	��100���� -    ��Name$ nextTxt��$��Следующая��$
��Left=�$��
284,93,0,0q�$	��Top=�
�������$��18(�$
��Bold"���Z� �� -    ��Name$ GameOverTxt��$
��Left=�$��298,249,0,0q�$
��Wrap=�$��Игра окончена��$	��Top=�
���  �� �� TextAlignment$ Center=�$��88��$	��145��$��30(�$
��Bold"� J� Effect -  'System.Windows.Media.Effects.BlurEffect     Radius$ 2Q�   RenderingBias$ Quality=��� -   $ levelTxt��$
��Left=�$��292.333,211,0,0q�$
��Wrap=�$��Уровень:��$	��Top=�
�������$��16(�$��156.667��$
��Bold"���Z� �� $
��Left=�$��
287,17,0,0q�$
��Wrap=�$��Счёт��$	��Top=�$��35��$	��166��#��� ��$��24(�$ Center=�#��� ���� -	   $ scoreTxt��$
��Left=�$��
287,51,0,0q�$
��Wrap=�$	��Top=�$��35��$	��166��#��� ��$��24(�$ Center=�#��� ��$��0��$
��Bold"�