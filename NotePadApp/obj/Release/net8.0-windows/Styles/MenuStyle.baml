   M S B A M L   `   `   `  ���� W  SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089   Menu.Static.Background  �� Color  Menu.Static.Border  Menu.Static.Foreground  Menu.Static.Separator  Menu.Disabled.Foreground   MenuItem.Selected.Background  MenuItem.Selected.Border ! MenuItem.Highlight.Background  MenuItem.Highlight.Border *	 &MenuItem.Highlight.Disabled.Background &
 "MenuItem.Highlight.Disabled.Border $  MenuScrollingVisibilityConverter  	DownArrow  UpArrow  
RightArrow  	Checkmark  MenuScrollButton �� 
TargetType �� BasedOn �� Property �� Value �� 
TargetType ��Name J� SnapsToDevicePixels �� 
ResourceId	 �� TypeInTargetAssembly
 � ColumnDefinitions � RowDefinitions �� CanContentScroll �� LineUpCommand �� RelativeSource �� Mode `� 	Converter `� ConverterParameter �� FallbackValue �� Path  HeaderFooterText �� LineDownCommand ��Name F�Name �� Triggers P� Value P� Property �� 
TargetName  MenuItem ]� 
Conditions �� Property �� Value �� CornerRadius �Name  � AllowsTransparency! � PlacementTarget" �� ElementName# �� Padding  SubMenu  HeaderFooter$ ��Name% �� ClearTypeHint& ��Name' ��Name( � IsSharedSizeScope-   'System.Windows.Input.KeyboardNavigation)    DirectionalNavigation*    TabNavigation+ P� 
SourceName, z� SharedSizeGroup- ��Name. J� Opacity/ m� InputGestureText0 � HorizontalOffset1 � VerticalOffset2 �� AncestorType3 �� Triggers�� F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      :x,http://schemas.microsoft.com/winfx/2006/xaml      %�#  &	        &	      &	 *     &	 ?     &	 T     &	 i     &	 ~     &	 �     &	 �     &		 �     &	
 �     &	 �     &	 �     &	     &	 *    &	 I    &	 �    (�� f    $ MenuScrollViewer��"	 �)7  7  7  7  7  7  (�� v    $ TopLevelItemTemplateKey��"	 m�)7  7  7  7  7 	 7 
 (�� 

    $ TopLevelHeaderTemplateKey��"	 m�)7  7  7  7  (�� "    $ SubmenuItemTemplateKey��"	 m�)7  7  7  7  7  7 	 7 
 (�� 9    $ SubmenuHeaderTemplateKey��"	 m�)7  7  7  7  7  7  7  'm� u    7   7  �� $  	#FFF0F0F0���� $  	#FF999999���� $  	#FF212121���� $  	#FFD7D7D7���� $  	#FF707070���� $  	#3D26A0DA���� $  	#FF26A0DA���� $  	#3D26A0DA���� $  	#FF26A0DA���� $  	#0A000000���� $  	#21000000��l� �M 0,0 L 3.5,4 L 7,0 Z��M 0,4 L 3.5,0 L 7,4 Z��M 0,0 L 4,3.5 L 0,7 Z��UQF1 M 10.0,1.2 L 4.7,9.1 L 4.5,9.1 L 0,5.2 L 1.3,3.5 L 4.3,6.1L 8.3,0 L 10.0,1.2 Z��� " �� Z� .���  �@��	ClickMode$ Hover=���  � �� �� " ��.R��� $ templateRoot��
������ 
������ $��1q�$
 true��._��� $��6q�$��Center=�$��Center=��� " �� Z� .���  � ��$ Hidden=���  � ��$
 Auto=���  � �� �� " ��.R�� $
 true��
 �� $��* � �� $
��Auto ��� $��* ��� $
��Auto �.+��� $��1��$��0��._��� #��z��# z���� $��0��$��0��#��Z $|�false��8��  ����  �� $ TemplatedParent=�y�`� 8  $ 0��$ Visibility.Collapsed��.1��� $) #ComputedVerticalScrollBarVisibility� �� $ TemplatedParent=��� $ VerticalOffset� �� $ TemplatedParent=��� $ ExtentHeight� �� $ TemplatedParent=��� $ ViewportHeight� �� $ TemplatedParent=�.��F� 8�� #���  �� $��2��$��0��#��Z $|�false��8�� ����  �� $ TemplatedParent=�y�`� 8  $	 100��$ Visibility.Collapsed��.1��� $) #ComputedVerticalScrollBarVisibility� �� $ TemplatedParent=��� $ VerticalOffset� �� $ TemplatedParent=��� $ ExtentHeight� �� $ TemplatedParent=��� $ ViewportHeight� �� $ TemplatedParent=�.��F� 8�� #���  �� " m�.R��� $ templateRoot��#��z��#��z��#��z��$
 true��._�� $��Center=�
 �� $
��Auto ��� $
��Auto �.+��� $
 Icon��$��16��$��16��$��3q�$��Center=�$��Center=�$
��Icon��# z F� $ 
GlyphPanel��$��3q�$��Center=�8��  #���  $��LeftToRight=�$y�	Collapsed=��� $��1��#��z��$��Header��$
��True��# z  P�  Z�  �@m�Icon. ��� $
 Icon�� � y�$ 	Collapsed=�P�  �@m�	IsChecked$
 true��. ��� $ 
GlyphPanel�� � y�$ Visible=��� $
 Icon�� � y�$ 	Collapsed=�P�  �@m�IsHighlighted$
 True��. ��� $ templateRoot��# �   � ���� $ templateRoot��8   � ��P�  � {�$ False��. ��� $ templateRoot��8   � ���� $ 
GlyphPanel��8   � ��]�  ��  �@m�IsHighlighted$
 True����  � {�$ False��./��� $ templateRoot��8   � ���� $ templateRoot��8   � ���� " m�.R��� $ templateRoot��$
��Auto��$��33��$��5,0,5,0q�$��Center=�$��Center=�
������ #��z��$��0q�$ 5��$
 true��._�� $��Center=�
 �� $
��Auto ��� $
��Auto �.+��� $
 Icon��$��16��$��16��$��3q�$��Center=�$��Center=�$
��Icon��# z F� $ 
GlyphPanel��$��3q�$��Center=�8��  #��z��$��LeftToRight=�$y�	Collapsed=��� $��1��#��z��$��Center=�$��Center=�$��Header��$
��True��# z � $ 
PART_Popup��$
  true��$|�false��$��Bottom=�#��� -����� *IsSubmenuOpen+ �� $ TemplatedParent=�! �� $" templateRoot��.���� $ SubMenuBorder��$# 2q�#���  #���  $��1q�$ 5��._��� $$ SubMenuScrollViewer����C� *�� $ MenuScrollViewer��"	 �+.��� $% Enabled=�.+��� $��0��$��0��$
��Left=�$	��Top=�$y�	Collapsed=�.+��� $& 
OpaqueRect��$y�	Collapsed=����� *ActualWidth+$" SubMenuBorder������ *ActualHeight+$" SubMenuBorder������ *
Background+$" SubMenuBorder���� $' ItemsPresenter��$
( true��$) Cycle=�$* Cycle=�# z  P� " �@m�IsSuspendingPopupAnimation$
 true��. ��� $ 
PART_Popup�� � ��$
 None=�P�  Z�  �@m�Icon. ��� $
 Icon�� � y�$ 	Collapsed=�P�  �@m�	IsChecked$
 true��. ��� $ 
GlyphPanel�� � y�$ Visible=��� $
 Icon�� � y�$ 	Collapsed=�P�  �@m�IsHighlighted$
 True��. ��� $ templateRoot��# �   � ���� $ templateRoot��8   � ��P�  � {�$ False��. ��� $ templateRoot��8   � ���� $ 
GlyphPanel��8   � ��P� $+ SubMenuScrollViewer�� � ��$ false��. ��� $ 
OpaqueRect�� �� *VerticalOffset+$" SubMenuScrollViewer�� �@��Top�� $ 
OpaqueRect�� �� *HorizontalOffset+$" SubMenuScrollViewer�� �@��Left�� " m�.R��� $ templateRoot��$��30��$��3q�#��z��#��z��$��0q�$ 5��$
 true��._�� $��-1q�
 �� $
��Auto �$, MenuItemIconColumnGroup���� $��13 ��� $��* ��� $��30 ��� $
��Auto �$, MenuItemIGTColumnGroup���� $��20 �.+��� $
 Icon��$��16��$��16��$��3q�$��Center=�$��Center=�$
��Icon��# z �� $ 
GlyphPanel��$��0��$��22��$��22��$��5,0,5,0q�$��Center=�$��Center=�
������ 8��  $��0q�$}�False��$y�	Collapsed=�._�F� $ Glyph��$��10��$��11��8�� #���  $��LeftToRight=��� $ menuHeaderContainer��$��1��$��2��$��5,0,0,0q�$
��Left=�$��Center=�$��Header��$
��True��# z �� $- menuGestureText��$��4��#��z��$��Center=�$	. 0.7Q�#��z/  P�  Z�  �@m�Icon. ��� $
 Icon�� � y�$ 	Collapsed=�P�  �@m�	IsChecked$
 True��. ��� $ 
GlyphPanel�� � y�$ Visible=��� $
 Icon�� � y�$ 	Collapsed=�P�  �@m�IsHighlighted$
 True��. ��� $ templateRoot��# �   � ���� $ templateRoot��8   � ��P�  � {�$ False��. ��� $ templateRoot��8   � ���� $ Glyph��8   � ��]�  ��  �@m�IsHighlighted$
 True����  � {�$ False��./��� $ templateRoot��8   � ���� $ templateRoot��8   � ���� " m�.R��� $ templateRoot��$��30��$��7,0,3,0q�
������ #��z��$��0q�$ 5��$
 true��._�� $��-1q�
 �� $
��Auto �$, MenuItemIconColumnGroup���� $��13 ��� $��* ��� $��30 ��� $
��Auto �$, MenuItemIGTColumnGroup���� $��20 �.+��� $
 Icon��$��16��$��16��$��3q�$��Center=�$��Center=�$
��Icon��# z �� $ 
GlyphPanel��$��22��$��22��$��-1,0,0,0q�$��Center=�#���  8��  $��1q�$y�Hidden=�._�F� $ Glyph��$��9��$��11��#���  #���  $��LeftToRight=��� $��1��$��2��#��z��$
��Left=�$��Center=�$��Header��$
��True��# z �� $��4��#��z��$��Center=�$	. 0.7Q�#��z/ F� $ 
RightArrow��$��5��$��10,0,0,0q�$
��Left=�$��Center=�8�� #���  � $ 
PART_Popup��$
  true��$|�false��$0 -2��$��Right=�#��� -�$1 -3������ *IsSubmenuOpen+ �� $ TemplatedParent=�.���� $ SubMenuBorder��$# 2q�#���  8�� $��0q�$ 5��._��� $$ SubMenuScrollViewer����C� *�� $ MenuScrollViewer��"	 �+.��� $% Enabled=�.+��� $��0��$��0��$
��Left=�$	��Top=�.+��� $& 
OpaqueRect��$y�	Collapsed=����� *ActualWidth+$" SubMenuBorder������ *ActualHeight+$" SubMenuBorder������ *
Background+$" SubMenuBorder���� $' ItemsPresenter��$
( true��$) Cycle=�$* Cycle=�# z  P� " �@m�IsSuspendingPopupAnimation$
 true��. ��� $ 
PART_Popup�� � ��$
 None=�P�  Z�  �@m�Icon. ��� $
 Icon�� � y�$ 	Collapsed=�P�  �@m�	IsChecked$
 True��. ��� $ 
GlyphPanel�� � y�$ Visible=��� $
 Icon�� � y�$ 	Collapsed=�P�  �@m�IsHighlighted$
 True��. ��� $ templateRoot��# �   � ���� $ templateRoot��8   � ��P�  � {�$ False��. ��� $ templateRoot��8   � ���� $ Glyph��8   � ���� $ 
RightArrow��8   � ��P� $+ SubMenuScrollViewer�� � ��$ false��. ��� $ 
OpaqueRect�� �� *VerticalOffset+$" SubMenuScrollViewer�� �@��Top�� $ 
OpaqueRect�� �� *HorizontalOffset+$" SubMenuScrollViewer�� �@��Left�� " m�.���  � �� �� *HorizontalContentAlignment+ �� "2 ����  � �� �� *VerticalContentAlignment+ �� "2 ����  � ��
 ���� ��  � ��
 ���� ��  � ��$ 1q���  �@��PanningMode$
 Both=���  �@��IsFlicksEnabled$ False����  � �� C� *�� $ SubmenuItemTemplateKey��"	 m�+3 P�  �@m�Role$ TopLevelHeader=�. ���  � ��
 ���� ��  � ��
 ���� ��  � ��# �  ��  � �� C� *�� $ TopLevelHeaderTemplateKey��"	 m�+��  � ��$	 6,0q�P�  �@m�Role$ TopLevelItem=�. ���  � ��8   ��  � ��8  ��  � ��# �  ��  � �� C� *�� $ TopLevelItemTemplateKey��"	 m�+��  � ��$	 6,0q�P�  �@m�Role$ SubmenuHeader=�. ���  � �� C� *�� $ SubmenuHeaderTemplateKey��"	 m�+