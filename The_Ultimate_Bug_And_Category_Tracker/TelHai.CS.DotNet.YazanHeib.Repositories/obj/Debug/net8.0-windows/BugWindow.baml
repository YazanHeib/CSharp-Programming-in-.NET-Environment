   M S B A M L   `   `   `  ����b  ^TelHai.CS.DotNet.YazanHeib.Repositories, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulla5clr-namespace:TelHai.CS.DotNet.YazanHeib.Repositories'TelHai.CS.DotNet.YazanHeib.Repositories  5   	   7    1TelHai.CS.DotNet.YazanHeib.Repositories.BugWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Glocal5clr-namespace:TelHai.CS.DotNet.YazanHeib.Repositories     5   	     � Title$  
Bug Window��5   	   $	��450��6   $	��820��6)   .��5	      � $��10q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��0,0,0,10q�6.   ���#E3F2FD.+�5      �� -   5         ��Name$ TitleTextBox��5      $	��200��6,   $��0,0,10,0q�68   $��Please Enter A Title:��6J   
�������6�   �� 5      -   5        $ DescriptionTextBox��5      $	��250��62   $��0,0,10,0q�6>   $!��Please Enter A Description:��6P   
�������6�   �� 5      -   5         ��Name$ StatusComboBox��5      $	��150��6/   $
��Bold"�6;   .@�5      �� $
��Open��6   ���#81C7846.   �� 5      $��In Progress��6   ���#64B5F665   �� 5      $��Closed��6   ���#E5737360   5      �� 5      -   5         ��Name$ SelectCategoryBtn��5      $��📂 Select Category��61   $	��150��6N   ���#E91E63
�������$
��Bold"�6�   $��10,0,0,0q�6�   5!      5#      &   System.Windows.Controls.DataGrid  5'   
   -   5          Name$ BugDataGrid��5'      $��1��6(      AutoGenerateColumns$ False��65      CanUserAddRows$ False��6Q   	   SelectionMode$	 Single=�6h   
�������
   AlternatingRowBackground
 �#E3F2FD   Columns 5(      0  *System.Windows.Controls.DataGridTextColumn  5)      ,  &System.Windows.Controls.DataGridColumn   Header$ Bug ID��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 50 6O   1  +System.Windows.Controls.DataGridBoundColumn   Binding 65   �� *BugID+6O     5*      $ Title��6%   $	 200 6N    64   �� *Title+6N     5+      $ Description��6%   $	 300 6Z    6:   �� *Description+6Z     5,      $ Status��6%   $	 150 6P    65   �� *Status+6P     5-      $ Category ID��6%   $	 100 6Y    6:   �� *
CategoryId+6Y   5/      �� 53   
   $��2��6   $ 
Horizontal=�6"   $��Center=�6;   $��0,10,0,0q�6X   ���#E3F2FD.+�54      �� -   5        $��📋 Add Bug��54      $	��165��6*   $��0,0,20,0q�66   ���#81C784
�������$
��Bold"�6�   �� 55      -   5        $��🗑 Delete Selected Bug��55      $	��165��66   $��0,0,20,0q�6B   ���#E57373
�������$
��Bold"�6�   �� 56      -   5        $��🔄 Update Selected Bug��56      $	��165��66   ���#64B5F6
�������$
��Bold"�6�   �� 57      -	   5        $��🏠 Return To Main Menu��57      $	��165��66   $��20,0,0,0q�6B   ���#FF9800
�������$
��Bold"�6�   58      5;      5=      