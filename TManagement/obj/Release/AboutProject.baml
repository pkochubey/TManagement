   M S B A M L   `   `   `  ���� F  BTManagement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:TManagement.ConvertersTManagement.Converters      TManagement.AboutProject   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     ;
converters$clr-namespace:TManagement.Converters       � Title$$  Время по проекту��$	��300��$	��338�� � ShowInTaskbar .   � Topmost .  � 
ResizeMode$ NoResize=� � WindowStartupLocation$ CenterOwner=� � WindowStyle$ 
ToolWindow=� � 	Resources 0   *TManagement.Converters.GroupHoursConverter   converterAllTime  headerStyle �� 
TargetType �� Property	 �� Value  contextMenu��%�   &	        &	      &	 /       �� " ��.���  � y�$	 	Collapsed=��� .@�m� -   $��Вошло в отчет��m� -   $��Проплачено��.��]� .+��� -   $��5q�$��Bottom=�$��Закрыть��$��Right=�$	��Top=�$��84��$��36���� -   $��ListViewTime��$��5q�
 �� View
 ��  �� AllowsColumnReorder .  ! �� ColumnHeaderContainerStyle# [ .P���  �� DisplayMemberBinding �� *Day+��  �� *Hours+��  �� Width$
 Auto�� �� CellTemplate �� .R��� ����  �� Path$ ImageBuy� �� ElementName$ ListViewTime�� �� 
GroupStyle (  "System.Windows.Controls.GroupStyle     ContainerStyle �� " ��.���  � ��	 �� .R�9�  9� 
IsExpanded . ����  �� Orientation$ 
Horizontal=�.+��� $��Неделя №��$��14(�
�������$��Bottom=��� $��14(�
�������$��Bottom=����� *Name+�� $�� общее время: ��$��14(�
�������$��Bottom=��� $��14(�
�������$��Bottom=����� *Items+ �� 	Converter# [  .���� ��  �@�ContextMenu#	 �  