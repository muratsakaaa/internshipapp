   M S B A M L   `   `   `  ����B  >SatisUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:SatisUI.UserControlsSatisUI.UserControls  5      '    !SatisUI.Views.PersonalUserControl   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35a ]DevExpress.Xpf.Core.v17.2, Version=17.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aF 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:SatisUI.UserControls     5      f bDevExpress.Xpf.Grid.v17.2.Core, Version=17.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aa ]DevExpress.Xpf.Grid.v17.2, Version=17.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a>dxg2http://schemas.devexpress.com/winfx/2008/xaml/grid   5      ?dxe5http://schemas.devexpress.com/winfx/2008/xaml/editors  5      -   5        .��5      �   � RowDefinitions  5   
   �� 5      $
��auto �6   �� 5      $��10 �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $��* �6   6+   .+�5   
   � -   5         �Name$ gridPersonelForm��5      
�������$y�	Collapsed=�6;   $��0��6R     5      �� 5      $��20 �6    �� 5      $��40 �6    �� 5      $��40 �6    �� 5      $��40 �6    �� 5      $��40 �6    �� 5      $��40 �6    �� 5      $��* �6     5       �� 5"      $	��130 �6#   �� 5#      $��70 �6#   �� 5$      $��70 �6#   �� 5%      $��70 �6#   �� 5&      $��70 �6#   �� 5'      $��70 �6#   �� 5(      $��70 �6#   �� 5)      $��* �6#   .+�5.      �� $��1��6   $��0��6%   $��8��65   �� 5/      $��2��6   $��0��6%   $��8��65   �� 50      $��3��6   $��0��6%   $��8��65   �� 51      $��4��6   $��0��6%   $��8��65   �� 52      $��5��6   $��0��6%   $��8��65   �� 53      $��6��6   $��0��6%   $��8��65   �� 54      $��1��6   $��0��6!   $��Personel Adı��61   
�������$��Center=�6[   $��14(�6v   $��Center=�6�   �� 55      $��2��6   $��0��6!   $��Personel Soyadı��61   
�������$��Center=�6^   $��Center=�6y   $��14(�6�   �� 56      $��3��6   $��0��6!   $��Personel Rolü��61   
�������$��Center=�6\   $��Center=�6w   $��14(�6�   �� 57      $��0��6   $��4��6$   $��Personel Foto��61   
�������$��Center=�6\   $��Center=�6w   $��14(�6�   �� 58      $��0��6   $��5��6$   $��Personel Username��61   
�������$��Center=�6`   $��Center=�6{   $��14(�6�   �� 59      $��0��6   $��6��6$   $��Personel Password��61   
�������$��Center=�6`   $��Center=�6{   $��14(�6�   %  DevExpress.Xpf.Editors.TextEdit  5:      -   5          Name$ personalName��5:      $��1��62   $��1��6?   $��8��6O   $��25��6c   $��10q�6r     5;      -   5        $ personelLastname��5;      $��2��65   $��1��6B   $��8��6R   $��25��6f   $��10q�6u     5<      -   5        $ personelUsername��5<      $��5��65   $��1��6B   $��8��6R   $��25��6f   $��10q�6u   5@      ,  &DevExpress.Xpf.Editors.PasswordBoxEdit  5A      -   5          Name$ personelPassword��5A   "   $��6��6<   $��1��6I   $��8��6Y   $��25��6m   $��10q�6|   5D      &   DevExpress.Xpf.Editors.CheckEdit  5E      -   5          Name$ chkboxAdmin��5E      
 � Tag$ 1��62   $��3��6:   $��1��6G   $��Right=�6W   $��Center=�6s   $��20��6�   6�     5F      -   5        $ 
chkboxUser��5F         	IsChecked$
 TrueY�61   $ 3��6B   $��3��6J   $��3��6W   $��Right=�6g   $��Center=�6�   $��20��6�   6�     5G      -	   5        $ chkboxUser2��5G      $ 4��61   $��3��69   $��4��6F   $��Right=�6V   $��Center=�6r   $��20��6�   6�   �� 5H      $��3��6   $��2��6%   $��Admin��65   
�������$��10,0,0,0q�6U   $
��Left=�6g   $��Center=�6�   �� 5I      $��3��6   $��4��6%   $
��User��65   
�������$��10,0,0,0q�6T   $
��left=�6f   $��Center=�6�   �� 5J      $��3��6   $��5��6%   $��User2��65   
�������$��10,0,0,0q�6U   $
��left=�6g   $��Center=�6�     5K      -
   5        $ Per_pic_url��5K      $��4��60   $��1��6=   $��3��6M   $��25��6a   $��5q�6p   �� 5M      -   5         ��Name$ Per_pic_upload��5M      $��4��6-   $��4��6:   $��2��6J   $��30��6^   $��70��6m   $��Yükle��6{   $��14(�6�   $
��Left=�6�   6�   &   DevExpress.Xpf.Editors.ImageEdit  5N      -   5        	  Name$	 	per_image��5N      $��4��6/   $��5��6<   $��30,0,0,0q�6L   $��40��6^   $
��Left=�6l   5O      %  DevExpress.Xpf.Grid.GridControl  5P   
   -   5        
  Name$
 gridcontrol_personel��5P   '   $��2��6   )  #DevExpress.Xpf.Grid.DataControlBase   AutoGenerateColumns$
 None=�6E   #   EnableSmartColumnsGeneration .    View 5Q      #  DevExpress.Xpf.Grid.TableView  5R         AllowPerPixelScrolling . &   DevExpress.Xpf.Grid.DataViewBase   NavigationStyle$	 Row=�6>      ShowTotalSummary .    AllowColumnMoving .     AllowResizing .     AllowEditing .  6�      Columns. 5T      $	  DevExpress.Xpf.Grid.GridColumn	  $
  DevExpress.Xpf.Grid.ColumnBase 
  	FieldName$ 
PersonelID��6   $  DevExpress.Xpf.Grid.BaseColumn   Visible .  64   	  5U         AllowResizing] YDevExpress.Data.v17.2, Version=17.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a5  /DevExpress.Utils.Design.DefaultBooleanConverter$
 True 6   $ 
PersonelAd��62      Header)  #DevExpress.Xpf.Core.ObjectConverter$ Personel Adı 6I    
  ShowInColumnChooser .  6_   	  5V         AllowMoving$ False 6   $ PersonelSoyad��61   $ Personel Soyad 6K    .  6c   	  5W      $ PersonelRol��6   $ Personel Rol 65    .  6K   	  5X      $ PersonelUsername��6    .  6:   	  5Y      $ PersonelPic��6   $ Personel Foto 65    .   
  EditSettings 5Z      7  1DevExpress.Xpf.Editors.Settings.ImageEditSettings  5[      6  0DevExpress.Xpf.Editors.Settings.BaseEditSettings   MaxWidth$ 40Q�6,   6<   5]      5_      5`      5b      