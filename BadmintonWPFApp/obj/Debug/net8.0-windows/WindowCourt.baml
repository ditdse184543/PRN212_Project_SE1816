   M S B A M L   `   `   `  ����J  FBadmintonWPFApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:BadmintonWPFAppBadmintonWPFApp  5   	   !    BadmintonWPFApp.WindowCourt   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:BadmintonWPFApp     5   	     � Title$  WindowCourt��5   	   $	��450��6   $	��789��6*    � WindowStartupLocation$ CenterScreen=�5	   	   
������ .��5      ��  �� CornerRadius$ 10��6   ��5   
   �� 5       �� ImageSource$1 +Images/photo-1626224583764-f87db24ac4ea.png��6    j� Stretch$
 None=�5       j� 
AlignmentY$	 Top=�6$    j� 
AlignmentX$ Center=�65   ._�5   
   �� $ 10��6   $��5q�6#    J� Opacity$
 0.92Q�67    �� Padding$ 20q�6F   ��5      �� 5      	 �� 
StartPoint$		 0,0&�6&   
 �� EndPoint$	
 1,1&�67   .��5      �  � Color$ #00ACFF��6#    � Offset$ 0Q�63   � 5      $ #462AD8��6#   $
 0.75Q�63   � 5      $ #46B8DA��6#   $ 1Q�63   5      ��5      �� 5      $		 1,1&�6&   $	
 1,0&�67   .��5      � $ #D1F0FF��6#   $ 0Q�63   � 5      $ #2C4D70��6#   $ 1Q�63   5      ._�5      �  � ColumnDefinitions 5       �� 5!      $
��198* �6'   �� 5"      $	��37* �6'    � RowDefinitions 5$      �� 5%      $
��Auto �6$   �� 5&      $��* �6$   �� 5'      $
��Auto �6$   .+�5*      ��  �� Orientation$ 
Horizontal=�6   $��Right=�66   $��0,10,10,222q�6R   $��2��6g   .+�5+      �� -   5         ��Name$ SearchTextBox��5+      $	��318��65   $��5q�6A   $��28��6L   
������� �� 
CaretBrush
 �����
�������5,   D   �� 5-      -   5        $�� ��5-      $��65��6(   $��5q�63   
����������#BBBBBB��5.      �� 5/      $! Images/icons8-search-16.png��6)   $
 None=�50   )   $ Center=�68   52      53      �� 55      -   5         ��Name$ lvData��55      $��0,59,0,0q�6+   $��2��6h   $��2��6y    �� View 56      �� 57      .P�58      �� $��Id��6-    �� DisplayMemberBinding 69   ��  �� Path$
 CoId��� 59      $
��Name��6-    6;   �� $ CoName��� 5:      $��Address��6-    6>   �� $ 	CoAddress��� 5;      $
��Info��6-    6;   �� $ CoInfo��� 5<      $��Price��6-    6<   �� $ CoPrice��� 5=      -   5        	image��$��Image��5=   <    �� CellTemplate 5>   "   �� 5?   &   .R�5@   *   �� $	��100��6R   $��60��6^   $��Uniform=�6j   ��60   �� *AbsoluteCoPath+6j   5A   '   5C      �� 5D      $��Status��6-    6=   �� $ CoStatus��� 5E      -   5        
action��$��Action��5E   =    5F   "   �� 5G   &   .R�5H   *   ��  ��Name$ Bookbtn��61   -   5        $
��Book��5H   B   $��75��6Q   $��5q�6\    
  color1#��[  6}   
�������6�   5I   '   5K      5L      5N      �� 5P      $ 
Horizontal=�6   $
��Left=�66   $��
10,10,0,10q�6Q   $��2��6e   .+�5Q      �� -   5        $
��Back��5Q      $��75��6,   $��5q�67    
 color4#��[ 6[   
�������6�   5R      5S      5T      5U      5W      