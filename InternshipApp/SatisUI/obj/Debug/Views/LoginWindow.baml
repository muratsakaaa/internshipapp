   M S B A M L   `   `   `  ����B  >SatisUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:SatisUI.ViewsSatisUI.Views  5   	       SatisUI.Views.LoginWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35a ]DevExpress.Xpf.Core.v17.2, Version=17.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aF 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:SatisUI.Views     5   	   ?dxe5http://schemas.devexpress.com/winfx/2008/xaml/editors  5   	   ;dx2http://schemas.devexpress.com/winfx/2008/xaml/core  5   	     � Title$  LoginWindow��5
   	   $	��400��6   $	��400��6*   .��5      � -   5         �Name$ LoginScreen��5      
������� � RowDefinitions 5   
   �� 5      $��80 �6   �� 5      $��40 �6   �� 5      $��40 �6   �� 5      $��40 �6   �� 5      $��40 �6   �� 5      $��40 �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      .+�5   
   ,  &DevExpress.Xpf.Editors.PasswordBoxEdit  -   5          Name$ txtbox_password��5   D   
�������
���   �$��4��6]   $��Center=�6r   $��4��6�   $��Center=�6�   $	��300��6�   �� 5   
   $��3��6   $��1��6   $��2��6-   $��Şifre��6B   $��Center=�6T   $��14(�6p   
�������$��Center=�6�   �� 5   
   $��1��6   $��1��6   $��2��6-   $��Kullanıcı Adı��6B   $��Center=�6]   $��14(�6y   
�������$��Center=�6�   %  DevExpress.Xpf.Editors.TextEdit  5    
   -   5          Name$ txtedit_username��5    =   
�������
���   �$��4��6W   $��2��6k   $��Center=�6x   $��Center=�6�   $	��300��6�   �� 5!   
   $��0��6   $��0��6   $��4��6-   $��Lütfen Giriş Yapınız��6B   $��Center=�6d   $��25(�6�   
�������$��Center=�6�   *  $DevExpress.Xpf.Editors.HyperlinkEdit  5"   
   $��3��6   $
��Left=�6,   $��8��6H   $	��Top=�6U      Text$ Şifreni mi Unuttun?��6m   $��8(�6�   
����  �6�   &   DevExpress.Xpf.Core.SimpleButton  5&   
   -   5          Name$ 	btn_login��5&      $��
Giriş Yap��6-   $��1��6A   $��Center=�6Q   $��5��6n   $��Center=�6|   $��2��6�   $��14(�6�   $��5q�6�   $	��100��6�   6�   5+      5,      