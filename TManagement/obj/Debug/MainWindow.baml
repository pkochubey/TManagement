   M S B A M L   `   `   `  ����  TManagement    TManagement.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$  Time Management��5   	   $	��344��6!   $	��536��6.    � WindowStartupLocation$ CenterScreen=�5   	    � 
ResizeMode$ CanMinimize=�6.    � Icon$ Images/icon.ico��5   "    � 	Resources 5         OverlayImage H� Drawing � Brush � Geometry �� Rect	 �� RadiusX
 �� RadiusY��%�   &	        H� 5   
    5	      I� 5
      ��5      � 
 �Gc�� 5      �� 5   "   $ 	0 0 16 16�64   $	 10Q�6E   $
 10Q�6R   5      5      5      5       � TaskbarItemInfo 5      *  $System.Windows.Shell.TaskbarItemInfo  5   
   .��5      ]� .+�5   
   �� -   5        $��ProjectListBox��5   ^   $
��Left=�6   $��Disabled=�6(   $
��Left=�5      $	��309��6-   $��5,5,5,5q�6:   $	��Top=�6K   $	��165��6c   $��12(�5       � ContextMenu 5      �� 5       .@�5!      m� -   5        $��Добавить��5!      61   m� 5"      -   5        $��Изменить��5"      61   m� 5#      -   5        $��Удалить��5#      60   5$      ��5'      �� 5(      .R�5)      �  � RowDefinitions 5*      �� 5+      $
��Auto �6,   �� 5,      $
��Auto �6,   .+�5.      �� $��0��6$   $
��Wrap=�6B   $
��Left=�6V   $��3q�5/   $   ��5.   1   �� 5/   $   50      51      53      ]� 55   
   $��5q�6   .+�56      �� $	��Top=�6   .+�57      ��  �� Orientation$ 
Horizontal=�6   .+�58      �� $	��160��6   $��За все время:��6(   $��16(�6@   $��Arial)�6N   $��Right=�59      �� 5:      -   5        $��AllTimeLabel��5:      $��0 ч. 0 м. 0 с.��60   $��16(�6I   $��Arial)�6W   $	��181��6j   5;      �� 5<      $ 
Horizontal=�6   .+�5=      �� $	��160��6   $&�� Последняя сессия:��6(   $��16(�6D   $��Arial)�6R   $��Right=�5>      �� 5?      -   5        $��LastSessionLabel��5?      $��0 ч. 0 м. 0 с.��64   $��16(�6M   $��Arial)�6[   $	��181��5@      5A      5B      �� 5C      -   5        $��StartButton��5C   -   $��Bottom=�6   $��
Старт��6@   $	��332��6P   $��Arial)�5D      $��72(�6(   $	��115��66   $	��Top=�6C   ���	#FF63B85F
�������{�.  5E   (   �� 5F      -	   5        $��	TimeLabel��5F      $��0 ч. 0 м.��6%   $��Center=�69   $��Center=�6V   $��Arial)�5G      $��72(�6'   5H      5J      5K      