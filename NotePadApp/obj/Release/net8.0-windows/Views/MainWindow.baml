   M S B A M L   `   `   `  ���� H  DNotePadApp, Version=2024.1.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:NotePadApp.Models.BehaviorsNotePadApp.Models.Behaviors  'clr-namespace:NotePadApp
NotePadApp  5clr-namespace:NotePadApp.ModelsNotePadApp.Models  =#clr-namespace:NotePadApp.PropertiesNotePadApp.Properties  5clr-namespace:NotePadApp.AssetsNotePadApp.Assets  =#clr-namespace:NotePadApp.ViewModelsNotePadApp.ViewModels  3clr-namespace:NotePadApp.ViewsNotePadApp.Views  !    NotePadApp.Views.MainWindow   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     7b)clr-namespace:NotePadApp.Models.Behaviors     @d2http://schemas.microsoft.com/expression/blend/2008     _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  $localclr-namespace:NotePadApp  Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  ,modelsclr-namespace:NotePadApp.Models  4
properties#clr-namespace:NotePadApp.Properties  (t1clr-namespace:NotePadApp.Assets  4
viewmodels#clr-namespace:NotePadApp.ViewModels  *viewsclr-namespace:NotePadApp.Views  -     � Title$  
MainWindow��$	��800��$	��450��$	��500��$	��300��'  !System.Windows.Shell.WindowChrome   WindowChrome      CaptionHeight$ 0Q�   CornerRadius$ 5��   GlassFrameThickness$ 5q�   NonClientFrameEdges$ Bottom=�   ResizeBorderThickness$ 5q�   UseAeroCaptionButtons$ False�� J� InputBindings �� 	 �� Gesture$	 Ctrl+N��
 �� Command
 �� *Tabs.NewTab+�� $	 Ctrl+Shift+N��
 �� *	NewWindow+�� $	 Ctrl+O��
 �� *Tabs.OpenTab+�� $	 Ctrl+S��
 �� *	Tabs.Save+�� $	 Ctrl+Shift+S��
 �� *Tabs.SaveAs+�� $	 
Ctrl+Alt+S��
 �� *Tabs.SaveAll+�� $	 Ctrl+P��
 �� *Tabs.PageSetup+�� $	 Ctrl+W��
 �� *Tabs.SelectedTabItem.Close+�� $	 Ctrl+Shift+W��
 �� *
CloseAll+�� $	 Delete��
 �� *Tabs.SelectedTabItem.Delete+�� $	 Ctrl+F��
 �� *Tabs.ShowFindDialog+ �� CommandParameter ��  �� RelativeSource ��  �� AncestorType" ��� $	 Ctrl+Q��
 �� *!DataContext.Font.ShowFontWindow+ �� !   NotePadApp.Views.MainWindow"   ��  �� " ��� $	 Ctrl+G��
 �� *GoTo+ ��  �� " ��� $	 Ctrl+H��
 �� *Tabs.ShowReplaceDialog+ ��  �� " ��� $	 F3��
 �� *
FindNext+ ��  �� " ��� $	 Shift+F3��
 �� *FindPrevious+ ��  �� " ��� $	 F5��
 �� *	Tabs.Date+�� $	 Ctrl+OemPlus��
 �� *View.ZoomIn+�� $	 Ctrl+OemMinus��
 �� *View.ZoomOut+�� $	 Ctrl+0��
 �� *View.RestoreView+.���  � RowDefinitions �� $��40 ��� $��33 ��� $��* ��� -    ��Name$ 	FooterRow��$��30 � � ColumnDefinitions �� $��* ��� $
��auto �.+��� $��0��   Tab#���   �� $��1��  HeaderFooter#���  �� $��1��#���  �� $��1��$	��0.6��$��Bottom=�#���   �� $��2��  Body#���  �� $��50��$��30��$��5,5,5,5q�$
��Left=�$��Center=�
������  �� Orientation$ 
Horizontal=�.+��� $��20��$��7,7,2,2q�$��/NotePadIcon.ico���� $	��150��$��30��$��Right=�$	��Top=�$ 
Horizontal=�.+��� -    ��Name$ MinimizeBtn��$��50��$��0q�$��Bottom=�$	����$��Segoe UI Symbol)�$
��10pt(�  BodyText#���    WindowNavBtn#���  �� -   $ 
RestoreBtn��$��50��$��0q�$��Segoe UI Symbol)�$
��11pt(�#���  #���  ���� *RestoreButton+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=��� -   $ CloseBtn��$��50��$��0q�$	��✕��$��Segoe UI Symbol)�$
��11pt(�#���    CloseWindowBtn#���     NotePadApp.Views.MenuView  -     Name$ menuView��$��1���� -    ��Name$ TabCtrl��$��0��$��3��$��0��$��2��$��	10,10,0,0q�$
��Left=�$
��Left=����� *	Tabs.List+ �� SelectedItem �� *Tabs.SelectedTabItem+$ TwoWay=� � 	Resources  �� DataType   NotePadApp.ViewModels.Tab%   NotePadApp.Views.TabContentView  Name��%3   (��       *, +)�� "  .R�  $ 
TabContent������  �� 
TargetType" ��.R��  �� $
��Auto ���  �� $
��auto ��� $��* �.+���  ��Name$ 	Conatiner��$��0q�$��Center=�$ 
Horizontal=�.+���  ��Name$ myScrollBar��$��0��$��0�� � Minimum$ 0Q� �� Orientation$ 
Horizontal=�  � SmallChange$	  100Q�$y�	Collapsed=�! � Maximum! �� *ScrollableWidth+" �� ElementName$" sv��
# � Tag# �� $" sv��$ �� ViewportSize$ �� *ViewportWidth+$" sv��% � Value% �� *HorizontalOffset+$" sv��$ OneWay=�*  $Microsoft.Xaml.Behaviors.Interaction&   	Behaviors& <   6NotePadApp.Models.Behaviors.ScrollViewerScrollBehavior  �� ' ��Name$' sv��$��0��$��20,0,0,0q�$
��Left=�$��Center=�$
��True��$
��Auto=�$
��Auto=����� " ��.R��  �� $
��auto ��� �� $
��auto �.+��� ( ��Name$( 
LeftScroll��$��0��$��20,0,0,0q�) �� LineLeftCommand#��Z) $	��⯇��  	AppSymbol#��[   ButtonTemplate#���  $y�	Collapsed=����� $" myScrollBar���� $��1���� $( RightScroll��$��2��$��10,0,0,0q�* �� LineRightCommand#��Z* $	��⯈��#��[ #���  ���� $" myScrollBar��.���� + ��Name$+ HeaderPanel��$��0��$��0��$��30��$��	10,0,10,0q�$��Center=�, K� ZIndex$, 1��- K� IsItemsHost$
- true��-  'System.Windows.Input.KeyboardNavigation.   TabIndex$. 1���� $ 	AddNewTab��$��0��$��0��$��0q�$��Right=�$��Center=�$	��➕��$��Right=�$	��9pt(�#��[ #���  ���� *Tabs.NewTab+�� / ��Name$/ PART_SelectedContentHost��$��1��$��0��$��2��$��
-10,40,0,5q�$
��Left=�$��SelectedContent��0 J� SnapsToDevicePixels#0 z0 ���� *ActualWidth+ �� *FindAncestor+" ����� Tab��"  .R�� $	��200��$��30��$��0q�$��Center=� �� $	��165 ��� $
��Auto �.+��� $��0��$��10,0,0,0q�$
��Left=�$��Center=�$	��9pt(����� 1 �� 
TargetType"1 ��2 �� Triggers2 �� 3 �� Binding3 �� *
IsSelected+ �� " ��4 �� Value	4 False.a��� 5 �� Property5 � ��6 �� Value$6 Normal"��� 3 �� *
IsSelected+ �� " ��4 True.a��� 5 � ��$6 Medium"��� ��� *Name+ 	   NotePadApp.Views.ThemeView	  $��1��!
   NotePadApp.Views.FooterView
  -   7 
 Name$7 Footer��$��3������ "1 
 2 �� 3 �� *View.IsFooterVisible+	4 False.a��� 5 � y�$6 	Collapsed=��� 3 �� *View.IsFooterVisible+4 True.a��� 5 � y�$6 Visible=�