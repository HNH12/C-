   M S B A M L   `   `   `  ����K  GProgram_for_exam, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:Program_for_examProgram_for_exam  5   	   #    Program_for_exam.CreateWorker   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:Program_for_exam     5   	     � Title$<  6Оформление нового сотрудника��5   	   $	��378��6.   $��683.6��6;   .��5
      � $��
0,-3,3.6,1q�6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ staffTableDataGrid��5      $��186,55,0,46q�6/      
IsReadOnly . $
��Left=�6W      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$! ФИО сотрудника��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$	 280 6a   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6=   ��  �� Path$ 
nameWorker�6a     5      $ Должность��6%   $	 160 6`    68   �� $ positionWorker�6`   5      �� 5   
   -   5         ��Name$ secondNameTextBox��5      $
��Left=�6-   $��23��6H   	 �� TextWrapping$
	 Wrap=�6T   $	��Top=�6h   $	��120��6�   $��	22,55,0,0q�6�   .��6�   
 � ToolTip
 5      _� 5      -   5         _�Name$ secondNameToolTip��5      $y�Hidden=�65   $��Укажите имя��6I   .��5      5      �� 5   
   -   5        $ firstNameTextBox��5      $
��Left=�6,   $��23��6G   $
	 Wrap=�6S   $	��Top=�6g   $	��120��6   $��
22,120,0,0q�6�   .��6�   
 5      _� 5      -   5        $ firstNameToolTip��5      $y�Hidden=�64   $��Укажите имя��6H   .��5      5      �� 5   
   -   5        $ middleNameTextBox��5      $
��Left=�6-   $��23��6H   $
	 Wrap=�6T   $	��Top=�6h   $	��120��6�   $��
22,179,0,0q�6�   .��6�   
 5       _� 5!      -   5        $ middleNameToolTip��5!      $y�Hidden=�65   $%��Укажите отчество��6I   .��5"      5#      �� 5%   
   $��Фамилия��6   $
��Left=�6"   $	��Top=�6=   $��	22,29,0,0q�6U   �� 5&   
   $��Имя��6   $
��Left=�6   $	��Top=�69   $��	22,89,0,0q�6Q   �� 5'   
   $��Отчество��6   $
��Left=�6#   $	��Top=�6>   $��
22,153,0,0q�6V   �� 5(   
   $��Должность��6   $
��Left=�6$   $	��Top=�6?   $��
22,209,0,0q�6W   �� 5*   
   -   5        $��Создать��5*      $
��Left=�6#   $	��Top=�6>   $��75��6V   $��
45,278,0,0q�6a   $��26��6u   6�   �� 5,   
   -	   5         ��Name$ staffComboBox��5,      $
��Left=�6*   $	��Top=�6E   $	��120��6]   $��
22,240,0,0q�6i   6}   �� 5.   
   -
   5         ��Name$ firstObjectLabel��5.      
���  ��$��20(�6;   $��!��6I   $	��Top=�6U   $��147,231,0,0q�6m    J� RenderTransformOrigin$ 0.53,-0.228&�6�   $��39��6�   $y�Hidden=�6�   $
��Left=�6�   $��16��6�   
 5/      _� 50      -   5        $ staffToolTip��50      $)��#Выберите должность��60   52      54      55      