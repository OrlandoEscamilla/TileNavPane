   M S B A M L   `   `   `  ����F  BTileNavPane, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:TileNavPane.ViewTileNavPane.View  5
      3clr-namespace:TileNavPane.ViewTileNavPane.View  5          TileNavPane.View.Cobro   5      a ]DevExpress.Xpf.Core.v22.1, Version=22.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aR NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      ;dx2http://schemas.devexpress.com/winfx/2008/xaml/core  5      ] YDevExpress.Mvvm.v22.1, Version=22.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aAdxmvvm2http://schemas.devexpress.com/winfx/2008/xaml/mvvm   5      Fmc;http://schemas.openxmlformats.org/markup-compatibility/2006   5      <d2http://schemas.microsoft.com/expression/blend/2008   5      a ]DevExpress.Xpf.Grid.v22.1, Version=22.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49af bDevExpress.Xpf.Grid.v22.1.Core, Version=22.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a>dxg2http://schemas.devexpress.com/winfx/2008/xaml/grid   5      <dxb2http://schemas.devexpress.com/winfx/2008/xaml/bars  5	      )viewclr-namespace:TileNavPane.View  5
      *localclr-namespace:TileNavPane.View  5      ?dxe5http://schemas.devexpress.com/winfx/2008/xaml/editors  6;   2  ,DevExpress.Mvvm.UI.Interactivity.Interaction    	Behaviors  5      -  'DevExpress.Xpf.Core.DXMessageBoxService  5   
   -   5          Name$ 	AlertaDlg��5   !   '  !DevExpress.Xpf.Core.DialogService  5   
   -   5          Name$ VentanaCobroDlg��5      "   DialogWindowStartupLocation$ CenterOwner=�64   (  "DevExpress.Mvvm.UI.ViewServiceBase   ViewTemplate 5      �� 5      .R�5      #   TileNavPane.View.VentanaCobro  5         DialogStyle 5      �� 5       �� 
TargetType(  "DevExpress.Xpf.Core.DXDialogWindow"  6   .�5      ��  �� Property �@�SizeToContent �� Value$ WidthAndHeight=�66   5      5      .��5%      $  DevExpress.Xpf.Bars.BarManager  	   Items	 5)   
   '  !DevExpress.Xpf.Bars.BarButtonItem  5*      -   5        
  Name$
 BarItemGuardar��5*       !	  DevExpress.Xpf.Bars.BarItem 	  BarItemDisplayMode$ ContentAndGlyph=�6d    	  Command 68   �� *RefrescarPedidosCommand+��5+      �� 5,      "  6   .�5-      ��  �@	 Content)
  #DevExpress.Xpf.Core.ObjectConverter$ Recargar Pedidos
 64   �� 5.       �@	 
LargeGlyph 67   ��  �� Source *  $DevExpress.Xpf.Core.DXImageExtension     Image1  +DevExpress.Xpf.Core.Native.DXImageConverter$ Recurrence_32x32.png  �� Triggers 5/      ^� 50       ^� 
Conditions 51   "   �� 52   &    �� Binding 60   �� *Id_Servicio+ �� Value 336P   �� 53   &    60   �� *Id_Solicitud+ 06Q   .0�55   "   ��  �@	 Content$ Generar Solicitudes
 6<   �� 56   "    �@	 
LargeGlyph 6?   ��    $ SavePageSetup_32x32.png 57      59      5;        5=      -   5        $
 BotonCobrarPedido��5=        � ToolTip$ Cobrar Pedido��6;    	  Content$ Cobrar Pedido
 6�   $ ContentAndGlyph=�6�    6S   �� *CobrarPedidoCommand+ 	  CommandParameter 6{   ��  �� ElementName$ 	gcPedidos�� �� Path$ SelectedItem� 	  
LargeGlyph 6�     $ Accounting_32x32.png  	  Glyph 65    $ Accounting_32x32.png   5?      -   5        $
 BarItemCerrar��5?       $ Eliminar Pedido��67   $ Eliminar Pedido
 6�   $ ContentAndGlyph=�6�    6Q   �� *CancelarPedidoCommand+ 6{   �� $ 	gcPedidos��$ SelectedItem� 6     $ Delete_32x32.png  61    $ Delete_32x32.png   5A      -   5        $
 BarItemDescargar��5A       $ Descargar Pedidos��6:   $ Descargar Pedidos
 6�   $ ContentAndGlyph=�6�    6V   �� *DescargarPedidosCommand+ 6�   �� $ 	gcPedidos��$ SelectedItem� 6	    $&  ExportModelDifferences_32x32.png  6J    $&  ExportModelDifferences_32x32.png    Bars 5E   
     DevExpress.Xpf.Bars.Bar  5F         Caption$
 bar1��6      AllowCustomizationMenu .     AllowQuickCustomization]	 YDevExpress.Data.v22.1, Version=22.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a5 	 /DevExpress.Utils.Design.DefaultBooleanConverter$ False 6D      	AllowHide$ False 6d      UseWholeRow$
 True 6v       DockInfo  5G      %  DevExpress.Xpf.Bars.BarDockInfo  5H      !   ContainerType$	! Top=�6&   /  )DevExpress.Xpf.Bars.BarItemLinkHolderBase"   Items." 5J      %  DevExpress.Xpf.Bars.BarItemLink  )  #DevExpress.Xpf.Bars.BarItemLinkBase#   BarItemName$# BarItemGuardar��6"     5K      $# BotonCobrarPedido��6"     5M      $# BarItemCerrar��6"     5N      $# BarItemDescargar��6"   5P      ._�5W   
   � .+�5Y      %  DevExpress.Xpf.Grid.GridControl  -   5        $  Name$$ 	gcPedidos��5Y   A   $	��540��6T   $
��auto��6a   $
��10,0q�6n   %   AutoExpandAllGroups% . )  #DevExpress.Xpf.Grid.DataControlBase&   ItemsSource& 6   �� *
DataSource+'   Columns' 5Z      $  DevExpress.Xpf.Grid.GridColumn  5[      $  DevExpress.Xpf.Grid.ColumnBase(   	FieldName$( 	ID_PEDIDO��6%   $  DevExpress.Xpf.Grid.BaseColumn)   Header$) 	ID_PEDIDO
 6;   *   ReadOnly* . 6N     5\      $( USUARIO_CAPTURA��6%   $) CAPTURADO POR
 6A   * . 6X     5]      $( 
FECHA_HORA��6%   $) 
FECHA_HORA
 6<   * . +   CellTemplate+ 5^      �� 5_      .R�5`   "   %  DevExpress.Xpf.Editors.TextEdit  $��PART_Editor��6/   %  DevExpress.Xpf.Editors.BaseEdit,   DisplayFormatString$, dd/MM/yyyy HH:mm:ss��6B   5a      5c        5d      $( ESTATUS��6%   $) ESTATUS
 69   * . -   
GroupIndex$- 1��6Z     5e      $( PARA_LLEVAR��6%   $) PARA LLEVAR
 6=   * . 6R     5f      $( NOMBRE_CLIENTE��6%   $) NOMBRE_CLIENTE
 6@   * . 6X     5g      $( TELEFONO_CLIENTE��6%   $) TELEFONO_CLIENTE
 6B   * . 6\     5h      $( COMENTARIOS��6%   $) COMENTARIOS
 6=   * . 6R     5i      $( TOTAL��6%   $) TOTAL
 67   * . 6F   .   DetailDescriptor. 5l      5  /DevExpress.Xpf.Grid.DataControlDetailDescriptor  5m      /   ItemsSourceBinding/ 66   �� *	Ordenes+0   DataControl.0 5n        1   AutoGenerateColumns$
1 None=�6*   ' 5o        5p   "   $( 	ID_PEDIDO��61   $) 	ID_PEDIDO
 6G   * . 6Z     5q   "   $( ID_ORDEN��61   $) ID_ORDEN
 6F   * . 6X     5r   "   $( ID_PRODUCTO��61   $) ID_PRODUCTO
 6I   * . 6^     5s   "   $( NOMBRE_PRODUCTO��61   $) NOMBRE_PRODUCTO
 6M   * . 6f     5t   "   $( CANTIDAD��61   $) CANTIDAD
 6F   * . 6X     5u   "   $( CON_TODO��61   $) CONTODO
 6F   * . 6W     5v   "   $( CON_TODO_MENOS��61   $) CON TODO MENOS
 6L   * . 6d     5w   "   $( COMENTARIOS��61   $) COMENTARIOS
 6I   * . 6^     5x   "   $( TOTAL_ORDEN��61   $) TOTAL
 6I   * . 6X   5z      5{      5}      5~      5      5�      