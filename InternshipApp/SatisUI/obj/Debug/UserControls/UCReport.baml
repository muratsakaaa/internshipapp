   M S B A M L   `   `   `  ����B  >SatisUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:SatisUI.UserControlsSatisUI.UserControls  5      #    SatisUI.UserControls.UCReport   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35a ]DevExpress.Xpf.Core.v17.2, Version=17.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aF 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:SatisUI.UserControls     5      f bDevExpress.Xpf.Grid.v17.2.Core, Version=17.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aa ]DevExpress.Xpf.Grid.v17.2, Version=17.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a>dxg2http://schemas.devexpress.com/winfx/2008/xaml/grid   5      ?dxe5http://schemas.devexpress.com/winfx/2008/xaml/editors  6M   -   5        .��5
      � .+�5   
   %  DevExpress.Xpf.Grid.GridControl  -   5           Name$  gridcontrol_report��5      )  #DevExpress.Xpf.Grid.DataControlBase   SelectionMode$	 Row=�66      View 5      #  DevExpress.Xpf.Grid.TableView  5         AllowPerPixelScrolling . &   DevExpress.Xpf.Grid.DataViewBase   ShowTotalSummary .    AllowEditing .     AllowColumnMoving .     AllowResizing .  6�      Columns. 5      $  DevExpress.Xpf.Grid.GridColumn  $  DevExpress.Xpf.Grid.BaseColumn'	    HorizontalHeaderContentAlignment$	 Center=�6   $  DevExpress.Xpf.Grid.ColumnBase
   	FieldName$
 SatisID��6G      ShowInColumnChooser .     EditSettings 5      6  0DevExpress.Xpf.Editors.Settings.TextEditSettings  5      6	  0DevExpress.Xpf.Editors.Settings.BaseEditSettings! 	  HorizontalContentAlignment$ Center=�6+   5        5      $	 Center=�6   $
 SatisPersonelAdi��6G      Header)
  #DevExpress.Xpf.Core.ObjectConverter$ Personel
 6d    5        5      $ Center=�6+   5        5      $	 Center=�6   $
 SatisMusteriAdi��6G    5        5      $ Center=�6+   5        5      $	 Center=�6   $
 
SatisTarih��6G    5         5!      $ Center=�6+   5#        5$      $	 Center=�6   $
 
SatisFiyat��6G    5%        5&       	  DisplayFormat$ $0��6+   $ Center=�6>   5(        5)      $	 Center=�6   $
 	SatisAdet��6G   $
 Adet
 6]    5*        5+      $ Center=�6+   5-        5.      $	 Center=�6   $
 SatisUrunAdi��6G   $ Ürün
 6`    5/        50      $ Center=�6+   52        53      
 6   Z� 54      56      57      