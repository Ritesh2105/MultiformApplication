   M S B A M L   `   `   `  ����O  KMultiformApplication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:MultiformApplicationMultiformApplication  5   	   )    #MultiformApplication.EmployeeWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:MultiformApplication     5   	     � Title$  Employee��5      $	��400��6   $	��360��6&    � 
ResizeMode$ NoResize=�62   .��5	      � 
������� � RowDefinitions 5
   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $��0��6   $��10q�6-   $��Employee_ID��69   
����  �6c   �� 5   
   $��0��6   $��1��6   $��10q�6/   $	��100��6;   ��6J   �� *SelectedEmployee.Employee_ID+�� 5   
   $��1��6   $��0��6   $��10q�6-   $
��Name��69   
����  �6\   �� 5   
   $��1��6   $��1��6   $��10q�6/   $	��100��6;   ��6J   �� *SelectedEmployee.Name+�� 5   
   $��2��6   $��0��6   $��10q�6-   $��	Position ��69   
����  �6a   �� 5   
   $��2��6   $��1��6   $��10q�6/   $	��100��6;   ��6J   �� *SelectedEmployee.Position+�� 5   
   $��3��6   $��0��6   $��10q�6-   $��Hourly pay rate��69   
����  �6g   �� 5   
   $��3��6   $��1��6   $��10q�6/   $	��100��6;   ��6J   �� *" SelectedEmployee.Hourly_pay_rate+�� 5   
   -   5        $
��Save��5   K   $��4��6   $��0��6   $
��30,5q�6.   $
��Save��6<   
���  ��$��30(�6{   �� 5   
   -   5        $��Delete��5   M   $��4��6   $��1��6   $
��30,5q�6.   $��Delete��6<   
���  ��$��30(�6�   5      5       