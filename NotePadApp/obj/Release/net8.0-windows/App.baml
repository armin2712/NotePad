   M S B A M L   `   `   `  ���� H  DNotePadApp, Version=2024.1.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:NotePadApp
NotePadApp  b ^PresentationFramework.Aero2, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35hKclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.Aero2Microsoft.Windows.Themes     NotePadApp.App   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     *localclr-namespace:NotePadApp     ]themeKclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.Aero2       �� 	Resources   �� MergedDictionaries �� Source   	AppSymbol �� 
TargetType �� Property �� Value  HeaderFooterText  Button.MouseOver.Background �� Color  Button.MouseOver.Border  Button.Pressed.Background  Button.Pressed.Border  Button.Disabled.Background  Button.Disabled.Border  Button.Disabled.Foreground 	 ButtonTemplate �� 
TargetType ��Name	 �� CornerRadius
 J� SnapsToDevicePixels ��Name �� Triggers P� Property P� Value �� 
TargetName 
 ButtonMouseOver  ButtonPressed  FocusVisual �� StrokeDashArray  TabItem.Static.Background  TabItem.Static.Border   TabItem.MouseOver.Background  TabItem.MouseOver.Border  TabItem.Selected.Background  TabItem.Selected.Border  TabItem.Disabled.Background  TabItem.Disabled.Border �Name ��Name  	Seperator F�Name  HeaderFooter �� Stretch J� Opacity �� RelativeSource �� AncestorType �� Orientation ��Name A�Name  IsSavedColor �� ScaleX  Tab ^� 
Conditions �� Binding �� Mode �� Value  NotSelectedTab  ]� 
Conditions! �� Property" �� Value# �� Binding��  �� $ /Themes/DarkTheme.xaml?��� $! /Styles/WindowNavStyle.xaml?��� $ /Styles/MenuStyle.xaml?��� $ /Styles/GoToButton.xaml?��� $  /Styles/ComboBoxStyle.xaml?��� $$ /Styles/ComboBoxItemStyle.xaml?�%�)  &	        &	 �     &	 �     &	     &	 #    &	 :    &	 O    &	 d    &		 y    &	 �    &	     &	 "    &	 9    &	 P    &	 g    &	 ~    &	 �    &	 �    '�� �    7   7 	 �� " ��.���  � ��
 ���� ��  � ��$ 0q���  � ��$ 30����  � ��$ 25����  � ��$
 10pt(���  � ��$ Segoe UI Symbol)���  � ��# �  ��  � ��$ Center=���  � ��$ Center=��� $ 	#BE312F38���� $
 Gray���� $ 	#E6312F38���� $ Transparent���� $ 	#FFF4F4F4���� $ 	#FFADB2B5���� $ 	#FF838383���� " ��.R��� $ border��#��z��#��z��#��z��$	 5��$

 true��._��� $ contentPresenter��#��z��$��Center=�$��Center=�$|�False��$
��True��#
 z
  P�  �@��IsDefaulted$
 true��. ��� $ border��# � �� � ��P�  �@J�IsMouseOver$
 true��. ��� $ border��# � 
  � ���� $ border��# �   � ��P�  � ��$
 true��. ��� $ border��# �   � ���� $ border��# �   � ��P�  � {�$ false��. ��� $ border��# �   � ���� $ border��# �   � ���� $ contentPresenter��# �   � ���� .���  � �� �� .R��� $��2q�$

 true��#��� ��$	 1 2R�$��1���� $ Transparent���� $ Transparent���� $ Transparent���� $ Transparent���� $ Transparent���� $ Transparent���� $ #F0F0F0���� $ #D9D9D9���� " ��.���  �@�FocusVisualStyle# �  ��  � ��# �  ��  � ��# �  ��  � ��# �  ��  � ��$ 0q���  � ��$ 6,2,6,2q���  � ��$ Stretch=���  � ��$ Stretch=���  � �� �� " ��.R�� $ templateRoot��$

 true��.+��� $ SeperatorTwo��$��1��$��15��$��0,0,10,0q�$
��Left=�$��Center=�#���  $y�Hidden=�F� $ 	LeftShape��$��25��$��30��$
��Left=�]���� -1 Zb�     Zb�     Zb� 	=  Zb���  Q%��� ���р�� ��� Ӏ��      $�  -1	#���  $ Uniform=�#���  $��1���� $ 
mainBorder��$��8,0,0,0q�#��z��#��z��$��0q�$	 	10 10 0 0��._��� $ innerBorder��$��-2q�#���  #���  $��0q�$	 	10 10 0 0��$ 0Q��� $ contentPresenter��#��z��$��Header��$|�False��$
��True��#
 z
 ���� *HorizontalContentAlignment+ �� " ������ *VerticalContentAlignment+ �� " ���� $��Right=�$��Center=�$ 
Horizontal=�.+�� .+��� $ CloseButton��$��0,0,8,0q�$	��✖��8��  8�� $y�Visible=����� *Close+A� $ IsSaved��$��6��$��6��$��0,0,19,0q�$��Right=�#���  $y�Visible=��� $ 	Seperator��$��1��$��15��$��0,0,-8,0q�$��Right=�$��Center=�#���  $y�Hidden=�F� $ 
RightShape��$��20��$��30��$��	0,0,-23,0q�$��Right=�]���� -1 Zb�     Zb�     Zb� 	=  Zb���  Q%��� ���р�� ��� Ӏ��      $�  -1	#���  $ Uniform=�#���  $��1��z��� $ -1Q��� $ InactiveLine��$	��250��$��1��$��
0,26,-40,0q�$��Center=�#���  $y�Hidden=� ^�  ��  �� *IsMouseOver+ �� $
 Self=� true��  �� *TabStripPlacement+ �� " �� Left.0��� $ 
mainBorder��# �   � ���� $ 
mainBorder��# �   � ���� $ innerBorder�� � ��$ 1,1,0,1q��� $ 
mainBorder�� � ��$ 1,1,0,1q��� $ 	Seperator�� � y�$ 	Collapsed=��� $ SeperatorTwo�� � y�$ 	Collapsed=��� $ IsSaved�� � y�$ 	Collapsed=��� $ CloseButton�� � y�$ Visible=�^�  ��  �� *IsMouseOver+ �� $
 Self=� true��  �� *TabStripPlacement+ �� " ��
 Bottom.0��� $ 
mainBorder��# �   � ���� $ 
mainBorder��# �   � ���� $ innerBorder�� � ��$ 1,0,1,1q��� $ 
mainBorder�� � ��$ 1,0,1,1q��� $ 	Seperator�� � y�$ 	Collapsed=��� $ SeperatorTwo�� � y�$ 	Collapsed=��� $ IsSaved�� � y�$ 	Collapsed=��� $ CloseButton�� � y�$ Visible=�^�  ��  �� *IsMouseOver+ �� $
 Self=� true��  �� *TabStripPlacement+ �� " ��	 Right.0��� $ 
mainBorder��# �   � ���� $ 
mainBorder��# �   � ���� $ innerBorder�� � ��$ 0,1,1,1q��� $ 
mainBorder�� � ��$ 0,1,1,1q��� $ 	Seperator�� � y�$ 	Collapsed=��� $ SeperatorTwo�� � y�$ 	Collapsed=��� $ CloseButton�� � y�$ Visible=�^�  ��  �� *IsMouseOver+ �� $
 Self=� true��  �� *TabStripPlacement+ �� " �� Top.0��� $ 
mainBorder��# �   � ���� $ 
mainBorder��# �   � ���� $ innerBorder�� � ��$ 1,1,1,0q��� $ 
mainBorder�� � ��$ 1,1,1,0q��� $ 	Seperator�� � y�$ 	Collapsed=��� $ SeperatorTwo�� � y�$ 	Collapsed=��� $ CloseButton�� � y�$ Visible=��� $ IsSaved�� � y�$ 	Collapsed=�^�  ��  �� *	IsEnabled+ �� $
 Self=�	 false��  �� *TabStripPlacement+ �� " �� Left.0��� $ contentPresenter�� �@J�Opacity$
 0.56Q��� $ 
mainBorder��# �   � ���� $ 
mainBorder��# �   � ���� $ innerBorder�� � ��$ 1,1,0,1q��� $ 
mainBorder�� � ��$ 1,1,0,1q�^�  ��  �� *	IsEnabled+ �� $
 Self=�	 false��  �� *TabStripPlacement+ �� " ��
 Bottom.0��� $ contentPresenter�� �@J�Opacity$
 0.56Q��� $ 
mainBorder��# �   � ���� $ 
mainBorder��# �   � ���� $ innerBorder�� � ��$ 1,0,1,1q��� $ 
mainBorder�� � ��$ 1,0,1,1q�^�  ��  �� *	IsEnabled+ �� $
 Self=�	 false��  �� *TabStripPlacement+ �� " ��	 Right.0��� $ contentPresenter�� �@J�Opacity$
 0.56Q��� $ 
mainBorder��# �   � ���� $ 
mainBorder��# �   � ���� $ innerBorder�� � ��$ 0,1,1,1q��� $ 
mainBorder�� � ��$ 0,1,1,1q�^�  ��  �� *	IsEnabled+ �� $
 Self=�	 false��  �� *TabStripPlacement+ �� " �� Top.0��� $ contentPresenter�� �@J�Opacity$
 0.56Q��� $ 
mainBorder��# �   � ���� $ 
mainBorder��# �   � ���� $ innerBorder�� � ��$ 1,1,1,0q��� $ 
mainBorder�� � ��$ 1,1,1,0q�^�  ��  �� *
IsSelected+ �� $
 Self=�	 false��  �� *TabStripPlacement+ �� " �� Left.0��� $ innerBorder�� � ��$ 1,1,0,1q��� $ 
mainBorder�� � ��$ 1,1,0,1q��� $ 	Seperator�� � y�$ Visible=��� $ SeperatorTwo�� � y�$ Visible=��� $ CloseButton�� � y�$ 	Collapsed=�^�  ��  �� *
IsSelected+ �� $
 Self=� true��  �� *TabStripPlacement+ �� " �� Left.0���  �@K�ZIndex$ 1����  � ��$ 
-2,-2,0,-2q��� $ innerBorder�� �@J�Opacity$ 1Q��� $ innerBorder�� � ��$ 1,1,0,1q��� $ 
mainBorder�� � ��$ 1,1,0,1q��� $ 	Seperator�� � y�$ 	Collapsed=��� $ SeperatorTwo�� � y�$ 	Collapsed=��� $ CloseButton�� � y�$ Visible=�^�  ��  �� *
IsSelected+ �� $
 Self=�	 false��  �� *TabStripPlacement+ �� " ��
 Bottom.0��� $ innerBorder�� � ��$ 1,0,1,1q��� $ 
mainBorder�� � ��$ 1,0,1,1q��� $ 	Seperator�� � y�$ Visible=��� $ SeperatorTwo�� � y�$ Visible=��� $ CloseButton�� � y�$ 	Collapsed=��� $ 	LeftShape�� � ��
 ���� �� $ 	LeftShape�� � ��
 ���� �� $ 
RightShape�� � ��
 ���� �� $ 
RightShape�� � ��
 ���� ^�  ��  �� *
IsSelected+ �� $
 Self=� true��  �� *TabStripPlacement+ �� " ��
 Bottom.0���  �@K�ZIndex$ 1����  � ��$ 
-2,0,-2,-2q��� $ innerBorder�� �@J�Opacity$ 1Q��� $ innerBorder�� � ��$ 1,0,1,1q��� $ 
mainBorder�� � ��$ 1,0,1,1q��� $ 	Seperator�� � y�$ 	Collapsed=��� $ SeperatorTwo�� � y�$ 	Collapsed=��� $ CloseButton�� � y�$ Visible=�^�  ��  �� *
IsSelected+ �� $
 Self=�	 false��  �� *TabStripPlacement+ �� " ��	 Right.0��� $ innerBorder�� � ��$ 0,1,1,1q��� $ 
mainBorder�� � ��$ 0,1,1,1q��� $ 	Seperator�� � y�$ Visible=��� $ SeperatorTwo�� � y�$ Visible=��� $ CloseButton�� � y�$ 	Collapsed=��� $ 	LeftShape�� � ��
 ���� �� $ 	LeftShape�� � ��
 ���� �� $ 
RightShape�� � ��
 ���� �� $ 
RightShape�� � ��
 ���� ^�  ��  �� *
IsSelected+ �� $
 Self=� true��  �� *TabStripPlacement+ �� " ��	 Right.0���  �@K�ZIndex$ 1����  � ��$ 
0,-2,-2,-2q��� $ innerBorder�� �@J�Opacity$ 1Q��� $ innerBorder�� � ��$ 0,1,1,1q��� $ 
mainBorder�� � ��$ 0,1,1,1q��� $ 	Seperator�� � y�$ 	Collapsed=��� $ SeperatorTwo�� � y�$ 	Collapsed=��� $ CloseButton�� � y�$ Visible=�^�  ��  �� *
IsSelected+ �� $
 Self=�	 false��  �� *TabStripPlacement+ �� " �� Top.0��� $ innerBorder�� � ��$ 1,1,1,0q��� $ 
mainBorder�� � ��$ 1,1,1,0q��� $ 	Seperator�� � y�$ Visible=��� $ CloseButton�� � y�$ 	Collapsed=��� $ 	LeftShape�� � ��
 ���� �� $ 	LeftShape�� � ��
 ���� �� $ 
RightShape�� � ��
 ���� �� $ 
RightShape�� � ��
 ���� ^�  ��  �� *
IsSelected+ �� $
 Self=� true��  �� *TabStripPlacement+ �� " �� Top.0���  �@K�ZIndex$ 1����  � ��$ 
-2,-2,-2,0q��� $ innerBorder�� �@J�Opacity$ 1Q��� $ innerBorder�� � ��$ 1,1,1,0q��� $ 
mainBorder�� � ��$ 1,1,1,0q��� $ 	Seperator�� � y�$ 	Collapsed=��� $ SeperatorTwo�� � y�$ 	Collapsed=��� $ CloseButton�� � y�$ Visible=�]�   �� ! �@J�IsMouseOver$
 True���� ! �@��
IsSelected$ False��./��� $ CloseButton�� � y�$ Visible=��� $ 	Seperator�� � y�$ 	Collapsed=��� $ SeperatorTwo�� � y�$ 	Collapsed=��� $ InactiveLine�� � y�$ Visible=��� $ IsSaved�� � y�$ 	Collapsed=��� $ 	LeftShape��# �   � ���� $ 	LeftShape��# �   � ���� $ 
RightShape��# �   � ���� $ 
RightShape��# �   � ���� $
" True��# �� *	IsSaved+.a��� $ IsSaved�� � y�$ 	Collapsed=��� $" False��# �� *	IsSaved+.a��� $ CloseButton�� � y�$ Hidden=�]�   �� ! �@J�IsMouseOver$
 True��./��� $ IsSaved�� � y�$ 	Collapsed=��� $ CloseButton�� � y�$ Visible=�