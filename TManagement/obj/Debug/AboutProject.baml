   M S B A M L   `   `   `  ����F  BTManagement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:TManagement.ConvertersTManagement.Converters  5   	       TManagement.AboutProject   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   ;
converters$clr-namespace:TManagement.Converters     5   	     � Title$$  Время по проекту��5   	   $	��300��6"   $	��338��6/    � ShowInTaskbar .   � Topmost .  � 
ResizeMode$ NoResize=�6`    � WindowStartupLocation$ CenterOwner=�5   	    � WindowStyle$ 
ToolWindow=�6-    � 	Resources 5      0   *TManagement.Converters.GroupHoursConverter   converterAllTime  headerStyle �� 
TargetType �� Property	 �� Value  contextMenu��%(  &	        &	      &	 b       5   
   6)   �� 5	   
   " ��6$   .�5
      ��  � y�$	 	Collapsed=�6+   5      �� 5   
   .@�5      m� -   5        $��Вошло в отчет��5      6.   m� 5      -   5        $��Проплачено��5      6+   5      5      .��5      ]� .+�5   
   �� -   5        $��5q�5      $��Bottom=�6   $��Закрыть��64   $��Right=�6F   $	��Top=�5      $��84��6)   $��36��64   6@   �� 5   
   -   5        $��ListViewTime��5      $��5q�6   
 �� View
 5      �� 5       �� AllowsColumnReorder .  ! �� ColumnHeaderContainerStyle# [ 67   .P�5      ��  �� DisplayMemberBinding 6%   �� *Day+�� 5       6%   �� *Hours+�� 5       �� Width$
 Auto��6%    �� CellTemplate 5      �� 5      .R�5   "   �� ��6(   ��  �� Path$ ImageBuy� �� ElementName$ ListViewTime��5      5      5        �� 
GroupStyle 5"      (  "System.Windows.Controls.GroupStyle  5#         ContainerStyle 5$      �� 5%      " ��6    .�5&      ��  � ��	 5'   "   �� 5(   &   .R�5)   *   9�  9� 
IsExpanded . ��5*   .   �� 5+   2    �� Orientation$ 
Horizontal=�6=   .+�5,   6   �� $��Неделя №��6@   $��14(�6P   
�������$��Bottom=�5-   @   �� 5.   6   $��14(�6V   
�������$��Bottom=�5/   @   ��5.   @   �� *Name+5/   @   �� 50   6   $�� общее время: ��6@   $��14(�6V   
�������$��Bottom=�51   @   �� 52   6   $��14(�54   9   
�������$��Bottom=�6[   ��53   9   �� *Items+ �� 	Converter# [  54   [   55   3   .��57   .   �� 58   +   59   '   5;      �� 5<       �@�ContextMenu#	 �  6<   5=      5?      5A      5B      5C      