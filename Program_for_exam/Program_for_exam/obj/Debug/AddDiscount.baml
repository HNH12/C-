   M S B A M L   `   `   `  ����K  GProgram_for_exam, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:Program_for_examProgram_for_exam  5   	   "    Program_for_exam.AddDiscount   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:Program_for_exam     5   	     � Title$'  !Добавление скидки��5   	   $��241.304��6#   $��924.636��64   .��5
      �  � RowDefinitions 5   
   �� 5      $
��113* �6   �� 5      $	��99* �6   .+�5   
   �� -   5         ��Name$ technicComboBox��5      $
��Left=�6,   $	��Top=�6G   $	��237��6_   $��	35,38,0,0q�6k   6~   �� 5   
   -   5        $��Добавить��5      $
��Left=�6$   $	��Top=�6?   $��75��6W   $��
197,93,0,0q�6b   $��20��6�   $��2��6�   �� 5   
   -   5         ��Name$ discountTextBox��5      $
��Left=�6+   $��20��6F    �� TextWrapping$
 Wrap=�6R   $	��Top=�6f   $��64��6~   $��	35,93,0,0q�6�   $��2��6�   .��6�    � ToolTip 5      _� 5      -   5         _�Name$ discountToolTip��5      $y�Hidden=�63   $H��BУкажите скидку (целое число от 1 до 99)��6G   .��5      5      �� 5   
   -   5        $��Удалить��5      $
��Left=�6#   $	��Top=�6>   $��75��6V   $��323,59.2,0,0q�6a   $��1��6�   $��22��6�   �� 5   
   -   5        $��Удалить все��5      $
��Left=�6'   $	��Top=�6B   $��75��6Z   $��
792,14,0,0q�6e   6y   �� 5   
   -   5        $ currentDiscountComboBox��5      $
��Left=�64   $	��Top=�6O   $	��453��6g   $��414,59.2,0,0q�6s   $��1��6�   6�   �� 5!   
   $��
Товар��6   $
��Left=�6    $	��Top=�6;   $��	35,15,0,0q�6S   �� 5"   
   $��Скидка��6   $
��Left=�6!   $	��Top=�6<   $��	35,67,0,0q�6T   �� 5$   
   -   5         ��Name$ firstObejctLabel��5$      $y�Hidden=�6*   $��!��6>   
���  ��$��20(�6[   $
��Left=�6i   $	��Top=�6�   $��
277,30,0,0q�6�   $��31��6�    5%      _� 5&      -	   5        $ productToolTip��5&      $y�Hidden=�62   $!��Выберите товар��6F   5(      �� 5*   
   -
   5        $ secondObjectLabel��5*      $��!��6+   $y�Hidden=�67   
���  ��$��20(�6\   $
��Left=�6j   $	��Top=�6�   $��867,50.2,0,0q�6�   $��1��6�    5+      _� 5,      -   5        $ deleteToolTip��5,      $y�Hidden=�61   $��Укажите товар��6E   5.      &   System.Windows.Controls.DataGrid  50   
   -   5          Name$ discountDataGrid��50      $
��Left=�6-   $	��120��6H   $	��Top=�6U   $��
323,38,0,0q�6m   $��2��6�   	   Columns	 51      0  *System.Windows.Controls.DataGridTextColumn  52      ,  &System.Windows.Controls.DataGridColumn
   Header$
 
Товар��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$	 450 6U   1  +System.Windows.Controls.DataGridBoundColumn   Binding 64   ��  �� Path$ product�6U     53      $
 Скидка��6%   $ 92 6W    65   �� $ discount�6W   55      57      58      