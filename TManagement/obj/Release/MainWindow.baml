   M S B A M L   `   `   `  ����   TManagement    TManagement.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     -     � Title$  Time Management��$	��344��$	��536�� � WindowStartupLocation$ CenterScreen=� � 
ResizeMode$ CanMinimize=� � Icon$ Images/icon.ico�� � 	Resources    OverlayImage H� Drawing � Brush � Geometry �� Rect	 �� RadiusX
 �� RadiusY��%W   &	        H�  I� ��� 
 �Gc�� �� $ 	0 0 16 16�$	 10Q�$
 10Q� � TaskbarItemInfo *  $System.Windows.Shell.TaskbarItemInfo  .��]� .+��� -   $��ProjectListBox��$
��Left=�$��Disabled=�$
��Left=�$	��309��$��5,5,5,5q�$	��Top=�$	��165��$��12(� � ContextMenu �� .@�m� -   $��Добавить��m� -   $��Изменить��m� -   $��Удалить������ .R��  � RowDefinitions �� $
��Auto ��� $
��Auto �.+��� $��0��$
��Wrap=�$
��Left=�$��3q����� ]� $��5q�.+��� $	��Top=�.+���  �� Orientation$ 
Horizontal=�.+��� $	��160��$��За все время:��$��16(�$��Arial)�$��Right=��� -   $��AllTimeLabel��$��0 ч. 0 м. 0 с.��$��16(�$��Arial)�$	��181���� $ 
Horizontal=�.+��� $	��160��$&�� Последняя сессия:��$��16(�$��Arial)�$��Right=��� -   $��LastSessionLabel��$��0 ч. 0 м. 0 с.��$��16(�$��Arial)�$	��181���� -   $��StartButton��$��Bottom=�$��
Старт��$	��332��$��Arial)�$��72(�$	��115��$	��Top=����	#FF63B85F
�������{�.  �� -	   $��	TimeLabel��$��0 ч. 0 м.��$��Center=�$��Center=�$��Arial)�$��72(�