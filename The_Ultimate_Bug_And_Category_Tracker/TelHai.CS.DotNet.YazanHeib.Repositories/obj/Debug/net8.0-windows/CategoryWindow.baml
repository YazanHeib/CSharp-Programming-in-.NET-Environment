   M S B A M L   `   `   `  ����b  ^TelHai.CS.DotNet.YazanHeib.Repositories, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulla5clr-namespace:TelHai.CS.DotNet.YazanHeib.Repositories'TelHai.CS.DotNet.YazanHeib.Repositories  5   	   <    6TelHai.CS.DotNet.YazanHeib.Repositories.CategoryWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Glocal5clr-namespace:TelHai.CS.DotNet.YazanHeib.Repositories     5   	     � Title$  Category Window��5   	   $	��450��6!   $	��800��6.   .��5	      � $��10q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��0,0,0,10q�6.   $��Center=�6@   $��Center=�6]   .+�5      �� -   5        $��📋 Add A Category��5      $	��175��61   $��0,0,20,0q�6=   ���#81C784
�������$
��Bold"�6�   �� 5      -   5        $��📂 Add A Sub-Category��5      $	��175��65   $��0,0,20,0q�6A   ���#9575CD
�������$
��Bold"�6�   5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ CategoryDataGrid��5      $��1��6-      AutoGenerateColumns$ False��6:      CanUserAddRows$ False��6V      SelectionMode$ Single=�6m   
�������   AlternatingRowBackground �#E3F2FD   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn	   Header$	 Category ID��6%   
   Width5  /System.Windows.Controls.DataGridLengthConverter$	
 155 6Q   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6:   �� *id+6Q     5      $	 Category Name��6%   $	
 300 6]    6<   �� *categoryName+6]     5      $	 Parent Category ID��6%   $	
 155 6f    6A   �� *parentCategoryId+6f     5       $	 Category / Sub-Category��6%   $	
 165 6g    6F   �� *categoryType+6g   5"      �� 5'   
   $��2��6   $ 
Horizontal=�6"   $��Center=�6;   $��0,10,0,0q�6X   ���#E3F2FD.+�5(      �� -   5        $#��🗑 Delete Selected Category��5(      $	��175��6;   $��0,0,20,0q�6G   ���#E57373
�������$
��Bold"�6�   �� 5)      -   5        $#��🔄 Update Selected Category��5)      $	��175��6;   ���#64B5F6
�������$
��Bold"�6�   �� 5*      -   5        $��🏠 Return To Main Menu��5*      $	��175��66   $��20,0,0,0q�6B   ���#FF9800
�������$
��Bold"�6�   5+      5.      5/      