   M S B A M L   `   `   `  ����B  >SatisUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:SatisUISatisUI  5   	       SatisUI.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35a ]DevExpress.Xpf.Core.v17.2, Version=17.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aF 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:SatisUI     5   	   <dxb2http://schemas.devexpress.com/winfx/2008/xaml/bars  5   	   d `DevExpress.Xpf.Docking.v17.2, Version=17.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a@dxdo5http://schemas.devexpress.com/winfx/2008/xaml/docking  6H   c _DevExpress.Xpf.Ribbon.v17.2, Version=17.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a>dxr4http://schemas.devexpress.com/winfx/2008/xaml/ribbon  6�   ;dx2http://schemas.devexpress.com/winfx/2008/xaml/core  6�   c _DevExpress.Xpf.NavBar.v17.2, Version=17.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a>dxn4http://schemas.devexpress.com/winfx/2008/xaml/navbar  6
    � Title$  
MainWindow��5	   	   $	��600��6   $
��1000��6)   .��5   
   � -   5         �Name$ ManinWindow��5       � RowDefinitions 5      �� 5      $
��auto �6    �� 5      $��* �6     � ColumnDefinitions 5      �� 5      $��* �6#   6/   .+�5      $  DevExpress.Xpf.Bars.BarManager  $��0��6   $��0��6-   ._�5      )  #DevExpress.Xpf.Ribbon.RibbonControl  -   5          Name$ RibbonControl��5   &   $��Stretch=�6=      
Categories. 5      5  /DevExpress.Xpf.Ribbon.RibbonDefaultPageCategory  2  ,DevExpress.Xpf.Ribbon.RibbonPageCategoryBase   Pages. 5      &   DevExpress.Xpf.Ribbon.RibbonPage  -   5          Name$ Ribbonpage_Home��5   8      Caption)  #DevExpress.Xpf.Core.ObjectConverter$
 Home 6)   	   Groups.	 5      +  %DevExpress.Xpf.Ribbon.RibbonPageGroup  -   5        
  Name$
 RibbonPageGroup_Home��5   D    �� 	IsEnabled .     Glyph 6b   *  $DevExpress.Xpf.Core.DXImageExtension     Image1	  +DevExpress.Xpf.Core.Native.DXImageConverter$ Save_32x32.png	    Caption 6�   Z�    Items. 5   "   '
  !DevExpress.Xpf.Bars.BarButtonItem
  -   5         
 Name$ 
saveButton��5   4   !  DevExpress.Xpf.Bars.BarItem   Content$
 SAVE 6H   
 � Tag$ 
AddNewItem��6W      RibbonStyle$	 All=�6�      
LargeGlyph 6h     $ Save_32x32.png	 6�   
  5   "   -   5        $ 	AddButton��5   4   $	 ADD 6G   $ 	NewRecord��6U    6e     $ Add_32x32.png	 6�   
  5    "   -   5        $ 
editButton��5    4   $
 EDIT 6H   $ EditItem��6W    6f     $ Edit_32x32.png	 6�   
  5"   "   -   5        $ deleteButton��5"   4   $ DELETE 6J   $ 
DeleteItem��6[    6l     $ Delete_32x32.png	 6�   
  5$   "   -	   5        $ cancelButton��5$   4   $ CANCEL 6J   $ 
CancelItem��6[    6l     $ Cancel_32x32.png	 6�   5%        5&      -
   5        $
 Ribbonpage_Logout��5&   A      IsCaptionButtonEnabled .   6.   Z� . 5(      
  -   5        $ 
btn_Logout��5(   0   $ LogOut 6D   $ Logout��6U    6b     $ BOPermission_32x32.png	    Glyph 6�     $ BOPermission_16x16.png	 5)      5*        5+      -   5        $ Ribbonpage_AlimSatim��5+   >   $ Alım Satım 6)   .	 5,        . 5-      
  -   5        $ 	basketAdd��5-   0   $ SEPET 6C   $ 
BasketShow��6s      	Alignment$	 Far=�6�    6�     $ BOOrderItem_32x32.png	  6�     $ BOOrderItem_16x16.png	 6�   
  5.      -   5        $ AcceptBasket��5.   B    .  $ Sepeti Onayla 6X   $	 Far=�6�   $ AcceptedBasket��6�    6�     $ Apply_32x32.png	  6�     $ Apply_32x32.png	 6�   
  5/      -   5        $ CancelBasket��5/   B    .  $ Sepet İptal 6X   $	 Far=�6�    6�     $ Cancel_32x32.png	  6�     $ BOOrderItem_16x16.png	 6�   50      51      52      53      55      .  (DevExpress.Xpf.Docking.DockLayoutManager  57   
   $��1��6!      
LayoutRoot. 58      (  "DevExpress.Xpf.Docking.LayoutGroup  +  %DevExpress.Xpf.Docking.BaseLayoutItem   Caption$ 
LayoutRoot��6       Items. 59      (  "DevExpress.Xpf.Docking.LayoutPanel  -   5          Name$ definePanel��59   $      
ShowBorder .  $��0��6M      	ItemWidth$
 Auto �6q   ��6Z   Z� (  "DevExpress.Xpf.Docking.ContentItem   Content. 5:      )  #DevExpress.Xpf.NavBar.NavBarControl  $	��200��6)      AllowSelectDisabledItem .    J� 	AllowDrop  .  !   Groups.! 5;      '  !DevExpress.Xpf.NavBar.NavBarGroup  -   5        "  Name$" navBar_tanimGroup��5;   *   #   Header$# 	Tanımlar 6E   $   Items.$ 5<      &   DevExpress.Xpf.NavBar.NavBarItem  -   5        %  Name$% navBar_uruntanim��5<   -   &   Content$& Ürün Tanımlama 6G   6`     5=      -   5        $% navBar_personeltanim��5=   -   $& Personel Tanımlama 6K   6h     5>      -   5        $% navBar_musteritanim��5>   -   $& Müşteri Tanımlama 6J   6f   5?        5@      -   5        $" navBar_listGroup��5@   *   $# Listele 6D   .$ 5A        -   5        $% navBar_urunList��5A   -   $& Ürün Listele 6F   6]     5B      -   5        $% navBar_raporList��5B   -   $& Rapor Listele 6G   6_   5C      5D      5F        5G      . 5H      &   DevExpress.Xpf.Core.DXTabControl  -   5        '  Name$' TabControlMain��5H   &   (   View( 5I      1  +DevExpress.Xpf.Core.TabControlMultiLineView  5J      5L      5M      5N      5O      5P      5T      