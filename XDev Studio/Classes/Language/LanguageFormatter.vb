Imports System.Text.RegularExpressions

Public Class LanguageFormatter

#Region "VB.Net"


    Public Shared Function FixVB(ByVal txt As String) As String
        '240
        Dim m As Match
        Dim strMatch As String
        Dim txtVBNetText As String = txt

        Dim regexStr As String = "\b(\w+\.\w+|\w+\.\w+\.\w+)\s\+\=\sNew\s(\w+|\w+.\w+.\w+.\w+)\((\w+_\w+|\w+\.\w+_\w+|\w+\.\w+)\)"   'AddHandler

        'playContextMenuStrip1.Items(contextMenuCount + i).MouseDown += new MouseEventHandler(PlayMenu_MouseDown)
        'playContextMenuStrip1.Items(i + 2).MouseDown += new MouseEventHandler(PlayMenu_MouseDown)
        Dim regexStr2 As String = "\b\w+\.\w+\((\w+\s\+\s\w\)\.\w+|\w+\s(\+|\-)\s(\w|\d{2})\)\.\w+)\s\+\=\s(New|new)\s\w+\(\w+_\w+\)" 'AddHandler #2

        Dim remregexStr As String = "\b(\w+\.\w+|\w+\.\w+\.\w+)\s\-\=\sNew\s(\w+|\w+.\w+.\w+.\w+)\((\w+\.\w+_\w+|\w+\.\w+)\)"   'RemoveHandler

        Dim remregexStr2 As String = "\w+_\w+\.\w+\s\-\=\s\w+_\w+" 'RemoveHandler #2.

        Dim patternIsInteger As String = "\bAs\sObject\s\=\s(\d+.|\w+.SelectedIndex)"   'Integer

        Dim patternClass As String = "\bAs\sObject\s\=\sNew\s\w+\(\)"                   'Class

        Dim patternTryCast As String = "\bAs\sObject\s\=\sTryCast\(e.Argument\,\s\w+\)" 'TryCast

        Dim patternSystemEventArgs As String = "\b\w+_(AcceptsTabChanged|AppearanceChanged|AutoSizeChanged|AutoValidateChanged|AvailableChanged|BackColorChanged|BackgroundImageChanged|BackgroundImageLayoutChanged" _
                                           & "|AllowUserToAddRowsChanged|AllowUserToDeleteRowsChanged|AllowUserToOrderColumnsChanged|AllowUserToResizeColumnsChanged|AllowUserToResizeRowsChanged|AlternatingRowsDefaultCellStyleChanged" _
                                           & "|AutoGenerateColumnsChanged|BeginDrag|BindingContextChanged|BorderStyleChanged|BalloonTipClicked|BalloonTipClosed|BalloonTipShown" _
                                           & "|CanGoForwardChanged|CanGoBackChanged|CellBorderStyleChanged|ColumnHeadersBorderStyleChanged|ColumnHeadersDefaultCellStyleChanged|ColumnHeadersHeightChanged|CurrentCellChanged" _
                                           & "|CurrentCellDirtyStateChanged|CausesValidationChanged|CheckedChanged|CheckStateChanged|Click|ClientSizeChanged|ContextMenuChanged|CurrentChanged|CurrentItemChanged" _
                                           & "|ContextMenuStripChanged|CurrentCellChanged|CursorChanged|Deactivate|DisplayMemberChanged||DataMemberChanged|DataSourceChanged|DefaultCellStyleChanged|Disposed|DockChanged|DoubleClick|DragLeave" _
                                           & "|DropDown|DropDownClosed|DropDownStyleChanged|DisplayStyleChanged|DocumentTitleChanged|EndDrag|EnabledChanged|EditModeChanged|Enter|Exited|EncryptionLevelChanged|FileDownload|FormatInfoChanged|FormatStringChanged|FormattingEnabledChanged" _
                                           & "|FontChanged|ForeColorChanged|GridColorChanged|GotFocus|HandleCreated|HandleDestroyed|HideSelectionChanged|IsOverwriteModeChanged|ImeModeChanged|Leave|LocationChanged" _
                                           & "|LostFocus|MaximizedBoundsChanged|MarginChanged|MaskChanged|MouseCaptureChanged|MaximumSizeChanged|MdiChildActivate|MenuComplete|MenuStart|MenuActivate|MenuDeactivate" _
                                           & "|MinimumSizeChanged|MouseCaptureChanged|Move|ModifiedChanged|MultilineChanged|PaddingChanged|ParentChanged|PropertySortChanged|Protected|RegionChanged" _
                                           & "|PositionChanged|ReadOnlyChanged|Resize|ResizeBegin|ResizeEnd|RecreateHandle|RightToLeftChanged|RightToLeftLayoutChanged|StatusTextChanged|SizeChanged|StyleChanged|SystemColorsChanged|StartPageChanged|TabIndexChanged" _
                                           & "|RowHeadersBorderStyleChanged|RowHeadersDefaultCellStyleChanged|RowHeadersWidthChanged|RowsDefaultCellStyleChanged|Opened" _
                                           & "|TabStopChanged|TextChanged|TextAlignChanged|Tick|Load|FormClosed|MouseEnter|MultiSelectChanged" _
                                           & "|MouseHover|MouseLeave|SelectionChangeCommitted|SelectedIndexChanged|SelectedItemChanged|SelectedObjectsChanged|SelectedValueChanged|Shown" _
                                           & "|TextBoxTextAlignChanged|ValueChanged|Validated|VisibleChanged|ValueMemberChanged|VScroll)" _
                                           & "\((ByVal\ssender\sAs\sObject\,\sByVal\se\sAs\s(EventArgs|System\.EventArgs)\)|sender\sAs\sObject\,\se\sAs\s(EventArgs|System\.EventArgs)\))"

        Dim patternDataGridViewRowCancelEventArgs As String = "\b\w+_UserDeletingRow\((ByVal\ssender\sAs\sObject\,\sByVal\se\sAs\sSystem\.Windows\.Forms\.DataGridViewRowCancelEventArgs\)|sender\sAs\sObject\,\se\sAs\sSystem\.Windows\.Forms\.DataGridViewRowCancelEventArgs\)|sender\sAs\sObject\,\se\sAs\sDataGridViewRowCancelEventArgs)\)"

        Dim patternDataGridViewSortCompareEventArgs As String = "\b\w+_SortCompare\((ByVal\ssender\sAs\sObject\,\sByVal\se\sAs\sSystem\.Windows\.Forms\.DataGridViewSortCompareEventArgs\)|sender\sAs\sObject\,\se\sAs\sSystem\.Windows\.Forms\.DataGridViewSortCompareEventArgs\)|sender\sAs\sObject\,\se\sAs\sDataGridViewSortCompareEventArgs)\)"

        Dim patternDataGridViewRowStateChangedEventArgs As String = "\b\w+_RowStateChanged\((ByVal\ssender\sAs\sObject\,\sByVal\se\sAs\sSystem\.Windows\.Forms\.DataGridViewRowStateChangedEventArgs\)|sender\sAs\sObject\,\se\sAs\sSystem\.Windows\.Forms\.DataGridViewRowStateChangedEventArgs\)|sender\sAs\sObject\,\se\sAs\sDataGridViewRowStateChangedEventArgs)\)"

        Dim patternDataGridViewRowsRemovedEventArgs As String = "\b\w+_RowsRemoved\((ByVal\ssender\sAs\sObject\,\sByVal\se\sAs\sSystem\.Windows\.Forms\.DataGridViewRowsRemovedEventArgs\)|sender\sAs\sObject\,\se\sAs\sSystem\.Windows\.Forms\.DataGridViewRowsRemovedEventArgs\)|sender\sAs\sObject\,\se\sAs\sDataGridViewRowsRemovedEventArgs)\)"

        Dim patternDataGridViewRowsAddedEventArgs As String = "\b\w+_RowsAdded\((ByVal\ssender\sAs\sObject\,\sByVal\se\sAs\sSystem\.Windows\.Forms\.DataGridViewRowsAddedEventArgs\)|sender\sAs\sObject\,\se\sAs\sSystem\.Windows\.Forms\.DataGridViewRowsAddedEventArgs\)|sender\sAs\sObject\,\se\sAs\sDataGridViewRowsAddedEventArgs)\)"

        Dim patternDataGridViewRowPrePaintEventArgs As String = "\b\w+_RowPrePaint\((ByVal\ssender\sAs\sObject\,\sByVal\se\sAs\sSystem\.Windows\.Forms\.DataGridViewRowPrePaintEventArgs\)|sender\sAs\sObject\,\se\sAs\sSystem\.Windows\.Forms\.DataGridViewRowPrePaintEventArgs\)|sender\sAs\sObject\,\se\sAs\sDataGridViewRowPrePaintEventArgs)\)"

        Dim patternDataGridViewRowPostPaintEventArgs As String = "\b\w+_RowPostPaint\((ByVal\ssender\sAs\sObject\,\sByVal\se\sAs\sSystem\.Windows\.Forms\.DataGridViewRowPostPaintEventArgs\)|sender\sAs\sObject\,\se\sAs\sSystem\.Windows\.Forms\.DataGridViewRowPostPaintEventArgs\)|sender\sAs\sObject\,\se\sAs\sDataGridViewRowPostPaintEventArgs)\)"

        Dim patternDataGridViewRowHeightInfoPushedEventArgs As String = "\b\w+_RowHeightInfoPushed\((ByVal\ssender\sAs\sObject\,\sByVal\se\sAs\sSystem\.Windows\.Forms\.DataGridViewRowHeightInfoPushedEventArgs\)|sender\sAs\sObject\,\se\sAs\sSystem\.Windows\.Forms\.DataGridViewRowHeightInfoPushedEventArgs\)|sender\sAs\sObject\,\se\sAs\sDataGridViewRowHeightInfoPushedEventArgs)\)"

        Dim patternDataGridViewRowHeightInfoNeededEventArgs As String = "\b\w+_RowHeightInfoNeeded\((ByVal\ssender\sAs\sObject\,\sByVal\se\sAs\sSystem\.Windows\.Forms\.DataGridViewRowHeightInfoNeededEventArgs\)|sender\sAs\sObject\,\se\sAs\sSystem\.Windows\.Forms\.DataGridViewRowHeightInfoNeededEventArgs\)|sender\sAs\sObject\,\se\sAs\sDataGridViewRowHeightInfoNeededEventArgs)\)"

        Dim patternDataGridViewRowErrorTextNeededEventArgs As String = "\b\w+_RowErrorTextNeeded\((ByVal\ssender\sAs\sObject\,\sByVal\se\sAs\sSystem\.Windows\.Forms\.DataGridViewRowErrorTextNeededEventArgs\)|sender\sAs\sObject\,\se\sAs\sSystem\.Windows\.Forms\.DataGridViewRowErrorTextNeededEventArgs\)|sender\sAs\sObject\,\se\sAs\sDataGridViewRowErrorTextNeededEventArgs)\)"

        Dim patternDataGridViewRowDividerDoubleClickEventArgs As String = "\b\w+_RowDividerDoubleClick\((ByVal\ssender\sAs\sObject\,\sByVal\se\sAs\sSystem\.Windows\.Forms\.DataGridViewRowDividerDoubleClickEventArgs\)|sender\sAs\sObject\,\se\sAs\sSystem\.Windows\.Forms\.DataGridViewRowDividerDoubleClickEventArgs\)|sender\sAs\sObject\,\se\sAs\sDataGridViewRowDividerDoubleClickEventArgs)\)"

        Dim patternDataGridViewRowContextMenuStripNeededEventArgs As String = "\b\w+_RowContextMenuStripNeeded\((ByVal\ssender\sAs\sObject\,\sByVal\se\sAs\sSystem\.Windows\.Forms\.DataGridViewRowContextMenuStripNeededEventArgs\)|sender\sAs\sObject\,\se\sAs\sSystem\.Windows\.Forms\.DataGridViewRowContextMenuStripNeededEventArgs\)|sender\sAs\sObject\,\se\sAs\sDataGridViewRowContextMenuStripNeededEventArgs)\)"

        Dim patternDataGridViewRowEventArgs As String = "\b\w+_(NewRowNeeded|RowContextMenuStripChanged|RowDefaultCellStyleChanged|RowDividerHeightChanged|RowErrorTextChanged" _
                                                        & "|RowHeaderCellChanged|RowHeightChanged|RowMinimumHeightChanged|RowUnshared|UserAddedRow|UserDeletedRow)" _
                                                        & "\((ByVal\ssender\sAs\sObject\,\sByVal\se\sAs\sSystem\.Windows\.Forms\.DataGridViewRowEventArgs\)|sender\sAs\sObject\,\se\sAs\sSystem\.Windows\.Forms\.DataGridViewRowEventArgs\)|sender\sAs\sObject\,\se\sAs\sDataGridViewRowEventArgs)\)"

        Dim patternDataGridViewEditingControlShowingEventArgs As String = "\b\w+_EditingControlShowing\((ByVal\ssender\sAs\sObject\,\sByVal\se\sAs\sSystem\.Windows\.Forms\.DataGridViewEditingControlShowingEventArgs\)|sender\sAs\sObject\,\se\sAs\sSystem\.Windows\.Forms\.DataGridViewEditingControlShowingEventArgs\)|sender\sAs\sObject\,\se\sAs\sDataGridViewEditingControlShowingEventArgs)\)"

        Dim patternDataGridViewDataErrorEventArgs As String = "\b\w+_DataError\((ByVal\ssender\sAs\sObject\,\sByVal\se\sAs\sSystem\.Windows\.Forms\.DataGridViewDataErrorEventArgs\)|sender\sAs\sObject\,\se\sAs\sSystem\.Windows\.Forms\.DataGridViewDataErrorEventArgs\)|sender\sAs\sObject\,\se\sAs\sDataGridViewDataErrorEventArgs)\)"

        Dim patternDataGridViewBindingCompleteEventArgs As String = "\b\w+_DataBindingComplete\((ByVal\ssender\sAs\sObject\,\sByVal\se\sAs\sSystem\.Windows\.Forms\.DataGridViewBindingCompleteEventArgs\)|sender\sAs\sObject\,\se\sAs\sSystem\.Windows\.Forms\.DataGridViewBindingCompleteEventArgs\)|sender\sAs\sObject\,\se\sAs\sDataGridViewBindingCompleteEventArgs)\)"

        Dim patternDataGridViewColumnStateChangedEventArgs As String = "\b\w+_ColumnStateChanged\((ByVal\ssender\sAs\sObject\,\sByVal\se\sAs\sSystem\.Windows\.Forms\.DataGridViewColumnStateChangedEventArgs\)|sender\sAs\sObject\,\se\sAs\sSystem\.Windows\.Forms\.DataGridViewColumnStateChangedEventArgs\)|sender\sAs\sObject\,\se\sAs\sDataGridViewColumnStateChangedEventArgs)\)"

        Dim patternDataGridViewAutoSizeModeEventArgs As String = "\b\w+_(RowHeadersWidthSizeModeChanged|ColumnHeadersHeightSizeModeChanged)\((ByVal\ssender\sAs\sObject\,\sByVal\se\sAs\sSystem\.Windows\.Forms\.DataGridViewAutoSizeModeEventArgs\)|sender\sAs\sObject\,\se\sAs\sSystem\.Windows\.Forms\.DataGridViewAutoSizeModeEventArgs\)|sender\sAs\sObject\,\se\sAs\sDataGridViewAutoSizeModeEventArgs)\)"

        Dim patternDataGridViewColumnEventArgs As String = "\b\w+_(ColumnAdded|ColumnContextMenuStripChanged|ColumnDataPropertyNameChanged|ColumnDefaultCellStyleChanged|ColumnDisplayIndexChanged|ColumnDividerWidthChanged" _
                                                           & "|ColumnHeaderCellChanged|ColumnMinimumWidthChanged|ColumnNameChanged|ColumnRemoved|ColumnSortModeChanged|ColumnToolTipTextChanged|ColumnWidthChanged)" _
                                                           & "\((ByVal\ssender\sAs\sObject\,\sByVal\se\sAs\sSystem\.Windows\.Forms\.DataGridViewColumnEventArgs\)|sender\sAs\sObject\,\se\sAs\sSystem\.Windows\.Forms\.DataGridViewColumnEventArgs\)|sender\sAs\sObject\,\se\sAs\sDataGridViewColumnEventArgs)\)"

        Dim patternDataGridViewCellValueEventArgs As String = "\b\w+_(CellValueNeeded|CellValuePushed)\((ByVal\ssender\sAs\sObject\,\sByVal\se\sAs\sSystem\.Windows\.Forms\.DataGridViewCellValueEventArgs\)|sender\sAs\sObject\,\se\sAs\sSystem\.Windows\.Forms\.DataGridViewCellValueEventArgs\)|sender\sAs\sObject\,\se\sAs\sDataGridViewCellValueEventArgs)\)"

        Dim patternDataGridViewCellValidatingEventArgs As String = "\b\w+_CellValidating\((ByVal\ssender\sAs\sObject\,\sByVal\se\sAs\sSystem\.Windows\.Forms\.DataGridViewCellValidatingEventArgs\)|sender\sAs\sObject\,\se\sAs\sSystem\.Windows\.Forms\.DataGridViewCellValidatingEventArgs\)|sender\sAs\sObject\,\se\sAs\sDataGridViewCellValidatingEventArgs)\)"

        Dim patternDataGridViewCellToolTipTextNeededEventArgs As String = "\b\w+_CellToolTipTextNeeded\((ByVal\ssender\sAs\sObject\,\sByVal\se\sAs\sSystem\.Windows\.Forms\.DataGridViewCellToolTipTextNeededEventArgs\)|sender\sAs\sObject\,\se\sAs\sSystem\.Windows\.Forms\.DataGridViewCellToolTipTextNeededEventArgs\)|sender\sAs\sObject\,\se\sAs\sDataGridViewCellToolTipTextNeededEventArgs)\)"

        Dim patternDataGridViewCellStyleContentChangedEventArgs As String = "\b\w+_CellStyleContentChanged\((ByVal\ssender\sAs\sObject\,\sByVal\se\sAs\sSystem\.Windows\.Forms\.DataGridViewCellStyleContentChangedEventArgs\)|sender\sAs\sObject\,\se\sAs\sSystem\.Windows\.Forms\.DataGridViewCellStyleContentChangedEventArgs\)|sender\sAs\sObject\,\se\sAs\sDataGridViewCellStyleContentChangedEventArgs)\)"

        Dim patternDataGridViewCellStateChangedEventArgs As String = "\b\w+_CellStateChanged\((ByVal\ssender\sAs\sObject\,\sByVal\se\sAs\sSystem\.Windows\.Forms\.DataGridViewCellStateChangedEventArgs\)|sender\sAs\sObject\,\se\sAs\sSystem\.Windows\.Forms\.DataGridViewCellStateChangedEventArgs\)|sender\sAs\sObject\,\se\sAs\sDataGridViewCellStateChangedEventArgs)\)"

        Dim patternDataGridViewCellParsingEventArgs As String = "\b\w+_CellParsing\((ByVal\ssender\sAs\sObject\,\sByVal\se\sAs\sSystem\.Windows\.Forms\.DataGridViewCellParsingEventArgs\)|sender\sAs\sObject\,\se\sAs\sSystem\.Windows\.Forms\.DataGridViewCellParsingEventArgs\)|sender\sAs\sObject\,\se\sAs\sDataGridViewCellParsingEventArgs)\)"

        Dim patternDataGridViewCellPaintingEventArgs As String = "\b\w+_CellPainting\((ByVal\ssender\sAs\sObject\,\sByVal\se\sAs\sSystem\.Windows\.Forms\.DataGridViewCellPaintingEventArgs\)|sender\sAs\sObject\,\se\sAs\sSystem\.Windows\.Forms\.DataGridViewCellPaintingEventArgs\)|sender\sAs\sObject\,\se\sAs\sDataGridViewCellPaintingEventArgs)\)"

        Dim patternDataGridViewCellMouseEventArgs As String = "\b\w+_(CellMouseClick|CellMouseDoubleClick|CellMouseDown|CellMouseMove|CellMouseUp" _
                                                              & "|ColumnHeaderMouseClick|ColumnHeaderMouseDoubleClick|RowHeaderMouseClick|RowHeaderMouseDoubleClick)" _
                                                              & "\((ByVal\ssender\sAs\sObject\,\sByVal\se\sAs\sSystem\.Windows\.Forms\.DataGridViewCellMouseEventArgs\)|sender\sAs\sObject\,\se\sAs\sSystem\.Windows\.Forms\.DataGridViewCellMouseEventArgs\)|sender\sAs\sObject\,\se\sAs\sDataGridViewCellMouseEventArgs)\)"

        Dim patternDataGridViewCellFormattingEventArgs As String = "\b\w+_CellFormatting\((ByVal\ssender\sAs\sObject\,\sByVal\se\sAs\sSystem\.Windows\.Forms\.DataGridViewCellFormattingEventArgs\)|sender\sAs\sObject\,\se\sAs\sSystem\.Windows\.Forms\.DataGridViewCellFormattingEventArgs\)|sender\sAs\sObject\,\se\sAs\sDataGridViewCellFormattingEventArgs)\)"

        Dim patternDataGridViewCellErrorTextNeededEventArgs As String = "\b\w+_CellErrorTextNeeded\((ByVal\ssender\sAs\sObject\,\sByVal\se\sAs\sSystem\.Windows\.Forms\.DataGridViewCellErrorTextNeededEventArgs\)|sender\sAs\sObject\,\se\sAs\sSystem\.Windows\.Forms\.DataGridViewCellErrorTextNeededEventArgs\)|sender\sAs\sObject\,\se\sAs\sDataGridViewCellErrorTextNeededEventArgs)\)"

        Dim patternDataGridViewCellContextMenuStripNeededEventArgs As String = "\b\w+_CellContextMenuStripNeeded\((ByVal\ssender\sAs\sObject\,\sByVal\se\sAs\sSystem\.Windows\.Forms\.DataGridViewCellContextMenuStripNeededEventArgs\)|sender\sAs\sObject\,\se\sAs\sSystem\.Windows\.Forms\.DataGridViewCellContextMenuStripNeededEventArgs\)|sender\sAs\sObject\,\se\sAs\sDataGridViewCellContextMenuStripNeededEventArgs)\)"

        Dim patternDataGridViewCellEventArgs As String = "\b\w+_(CellClick|CellContentClick|CellContentDoubleClick|CellContextMenuStripChanged|CellDoubleClick|CellEndEdit|CellEnter|CellErrorTextChanged|CellLeave" _
                                                         & "|CellMouseEnter|CellMouseLeave|CellStyleChanged|CellToolTipTextChanged|CellToolTipTextChanged|CellValidated|CellValueChanged|RowEnter|RowLeave|RowValidated)" _
                                                         & "\((ByVal\ssender\sAs\sObject\,\sByVal\se\sAs\sSystem\.Windows\.Forms\.DataGridViewCellEventArgs\)|sender\sAs\sObject\,\se\sAs\sSystem\.Windows\.Forms\.DataGridViewCellEventArgs\)|sender\sAs\sObject\,\se\sAs\sDataGridViewCellEventArgs)\)"

        Dim patternDataGridViewCellCancelEventArgs As String = "\b\w+_(CellBeginEdit|RowValidating)\((ByVal\ssender\sAs\sObject\,\sByVal\se\sAs\sSystem\.Windows\.Forms\.DataGridViewAutoSizeColumnModeEventArgs\)|sender\sAs\sObject\,\se\sAs\sSystem\.Windows\.Forms\.DataGridViewAutoSizeColumnModeEventArgs\)|sender\sAs\sObject\,\se\sAs\sDataGridViewAutoSizeColumnModeEventArgs)\)"

        Dim patternQuestionEventArgs As String = "\b\w+_(CancelRowEdit|RowDirtyStateNeeded)\((ByVal\ssender\sAs\sObject\,\sByVal\se\sAs\sSystem\.Windows\.Forms\.DataGridViewAutoSizeColumnModeEventArgs\)|sender\sAs\sObject\,\se\sAs\sSystem\.Windows\.Forms\.DataGridViewAutoSizeColumnModeEventArgs\)|sender\sAs\sObject\,\se\sAs\sDataGridViewAutoSizeColumnModeEventArgs)\)"

        Dim patternDataGridViewAutoSizeColumnModeEventArgs As String = "\b\w+_(AutoSizeColumnModeChanged|AutoSizeColumnsModeChanged)\((ByVal\ssender\sAs\sObject\,\sByVal\se\sAs\sSystem\.Windows\.Forms\.DataGridViewAutoSizeColumnModeEventArgs\)|sender\sAs\sObject\,\se\sAs\sSystem\.Windows\.Forms\.DataGridViewAutoSizeColumnModeEventArgs\)|sender\sAs\sObject\,\se\sAs\sDataGridViewAutoSizeColumnModeEventArgs)\)"

        Dim patternRenamedEventArgs As String = "\b\w+_Renamed\((ByVal\ssender\sAs\sObject\,\sByVal\se\sAs\sSystem\.IO\.ErrorEventArgs\)|sender\sAs\sObject\,\se\sAs\sSystem\.IO\.RenamedEventArgs\)|sender\sAs\sObject\,\se\sAs\sRenamedEventArgs)\)"

        Dim patternErrorEventArgs As String = "\b\w+_Error\((ByVal\ssender\sAs\sObject\,\sByVal\se\sAs\sSystem\.IO\.ErrorEventArgs\)|sender\sAs\sObject\,\se\sAs\sSystem\.IO\.ErrorEventArgs\)|sender\sAs\sObject\,\se\sAs\sErrorEventArgs)\)"

        Dim patternFileSystemEventArgs As String = "\b\w+_(Changed|Created|Deleted)\((ByVal\ssender\sAs\sObject\,\sByVal\se\sAs\sSystem\.IO\.FileSystemEventArgs\)|sender\sAs\sObject\,\se\sAs\sSystem\.IO\.FileSystemEventArgs\)|sender\sAs\sObject\,\se\sAs\sFileSystemEventArgs)\)"

        Dim patternEntryWrittenEventArgs As String = "\b\w+_EntryWritten\((ByVal\ssender\sAs\sObject\,\sByVal\se\sAs\sSystem\.Windows\.Forms\.EntryWrittenEventArgs\)|sender\sAs\sObject\,\se\sAs\sSystem\.Windows\.Forms\.EntryWrittenEventArgs\)|sender\sAs\sObject\,\se\sAs\sEntryWrittenEventArgs)\)"

        Dim patternListViewVirtualItemsSelectionRangeChangedEventArgs As String = "\b\w+_VirtualItemsSelectionRangeChanged\((ByVal\ssender\sAs\sObject\,\sByVal\se\sAs\sSystem\.Windows\.Forms\.ListViewVirtualItemsSelectionRangeChangedEventArgs\)|sender\sAs\sObject\,\se\sAs\sSystem\.Windows\.Forms\.ListViewVirtualItemsSelectionRangeChangedEventArgs\)|sender\sAs\sObject\,\se\sAs\sListViewVirtualItemsSelectionRangeChangedEventArgs)\)" '#68
        '(-----------------------------Start Here and Work Down)
        Dim patternSearchForVirtualItemEventArgs As String = "\b\w+_SearchForVirtualItem\((ByVal\ssender\sAs\sObject\,\sByVal\se\sAs\sSystem\.Windows\.Forms\.RetrieveVirtualItemEventArgs\)|sender\sAs\sObject\,\se\sAs\sSystem\.Windows\.Forms\.RetrieveVirtualItemEventArgs\)|sender\sAs\sObject\,\se\sAs\sRetrieveVirtualItemEventArgs)\)"

        Dim patternRetrieveVirtualItemEventArgs As String = "\b\w+_RetrieveVirtualItem\((ByVal\ssender\sAs\sObject\,\sByVal\se\sAs\sSystem\.Windows\.Forms\.RetrieveVirtualItemEventArgs\)|sender\sAs\sObject\,\se\sAs\sSystem\.Windows\.Forms\.RetrieveVirtualItemEventArgs\)|sender\sAs\sObject\,\se\sAs\sRetrieveVirtualItemEventArgs)\)"

        Dim patternListViewItemSelectionChangedEventArgs As String = "\b\w+_ItemSelectionChanged\((ByVal\ssender\sAs\sObject\,\sByVal\se\sAs\sSystem\.Windows\.Forms\.ListViewItemSelectionChangedEventArgs\)|sender\sAs\sObject\,\se\sAs\sSystem\.Windows\.Forms\.ListViewItemSelectionChangedEventArgs\)|sender\sAs\sObject\,\se\sAs\sListViewItemSelectionChangedEventArgs)\)"

        Dim patternListViewItemMouseHoverEventArgs As String = "\b\w+_ItemMouseHover\((ByVal\ssender\sAs\sObject\,\sByVal\se\sAs\sSystem\.Windows\.Forms\.ListViewItemMouseHoverEventArgs\)|sender\sAs\sObject\,\se\sAs\sSystem\.Windows\.Forms\.ListViewItemMouseHoverEventArgs\)|sender\sAs\sObject\,\se\sAs\sListViewItemMouseHoverEventArgs)\)"

        Dim patternItemDragEventArgs As String = "\b\w+_ItemDrag\((ByVal\ssender\sAs\sObject\,\sByVal\se\sAs\sSystem\.Windows\.Forms\.ItemDragEventArgs\)|sender\sAs\sObject\,\se\sAs\sSystem\.Windows\.Forms\.ItemDragEventArgs\)|sender\sAs\sObject\,\se\sAs\sItemDragEventArgs)\)"

        Dim patternItemCheckEventArgs As String = "\b\w+_ItemCheck\((ByVal\ssender\sAs\sObject\,\sByVal\se\sAs\sSystem\.Windows\.Forms\.ItemCheckEventArgs\)|sender\sAs\sObject\,\se\sAs\sSystem\.Windows\.Forms\.ItemCheckEventArgs\)|sender\sAs\sObject\,\se\sAs\sItemCheckEventArgs)\)"

        Dim patternDrawListViewItemEventArgs As String = "\b\w+_DrawItem\((ByVal\ssender\sAs\sObject\,\sByVal\se\sAs\sSystem\.Windows\.Forms\.DrawListViewItemEventArgs\)|sender\sAs\sObject\,\se\sAs\sSystem\.Windows\.Forms\.DrawListViewItemEventArgs\)|sender\sAs\sObject\,\se\sAs\sDrawListViewItemEventArgs)\)"

        Dim patternDrawListViewSubItemEventArgs As String = "\b\w+_DrawSubItem\((ByVal\ssender\sAs\sObject\,\sByVal\se\sAs\sSystem\.Windows\.Forms\.DrawListViewSubItemEventArgs\)|sender\sAs\sObject\,\se\sAs\sSystem\.Windows\.Forms\.DrawListViewSubItemEventArgs\)|sender\sAs\sObject\,\se\sAs\sDrawListViewSubItemEventArgs)\)"

        Dim patternDrawListViewColumnHeaderEventArgs = "\b\w+_DrawColumnHeader\((ByVal\ssender\sAs\sObject\,\sByVal\se\sAs\sSystem\.Windows\.Forms\.DrawListViewColumnHeaderEventArgs\)|sender\sAs\sObject\,\se\sAs\sSystem\.Windows\.Forms\.DrawListViewColumnHeaderEventArgs\)|sender\sAs\sObject\,\se\sAs\sDrawListViewColumnHeaderEventArgs)\)"

        Dim patternColumnWidthChangingEventArgs As String = "\b\w+_ColumnWidthChanging\((ByVal\ssender\sAs\sObject\,\sByVal\se\sAs\sSystem\.Windows\.Forms\.ColumnWidthChangingEventArgs\)|sender\sAs\sObject\,\se\sAs\sSystem\.Windows\.Forms\.ColumnWidthChangingEventArgs\)|sender\sAs\sObject\,\se\sAs\sColumnWidthChangingEventArgs)\)"

        Dim patternColumnWidthChangedEventArgs As String = "\b\w+_ColumnWidthChanged\((ByVal\ssender\sAs\sObject\,\sByVal\se\sAs\sSystem\.Windows\.Forms\.ColumnWidthChangedEventArgs\)|sender\sAs\sObject\,\se\sAs\sSystem\.Windows\.Forms\.ColumnWidthChangedEventArgs\)|sender\sAs\sObject\,\se\sAs\sColumnWidthChangedEventArgs)\)"

        Dim patternColumnReorderedEventArgs As String = "\b\w+_ColumnReordered\((ByVal\ssender\sAs\sObject\,\sByVal\se\sAs\sSystem\.Windows\.Forms\.ColumnReorderedEventArgs\)|sender\sAs\sObject\,\se\sAs\sSystem\.Windows\.Forms\.ColumnReorderedEventArgs\)|sender\sAs\sObject\,\se\sAs\sColumnReorderedEventArgs)\)"

        Dim patternColumnClickEventArgs As String = "\b\w+_ColumnClick\((ByVal\ssender\sAs\sObject\,\sByVal\se\sAs\sSystem\.Windows\.Forms\.ColumnClickEventArgs\)|sender\sAs\sObject\,\se\sAs\sSystem\.Windows\.Forms\.ColumnClickEventArgs\)|sender\sAs\sObject\,\se\sAs\sColumnClickEventArgs)\)"

        Dim patternCacheVirtualItemsEventArgs As String = "\b\w+_CacheVirtualItems\((ByVal\ssender\sAs\sObject\,\sByVal\se\sAs\sSystem\.Windows\.Forms\.CacheVirtualItemsEventArgs\)|sender\sAs\sObject\,\se\sAs\sSystem\.Windows\.Forms\.CacheVirtualItemsEventArgs\)|sender\sAs\sObject\,\se\sAs\sCacheVirtualItemsEventArgs)\)"

        Dim patternLabelEditEventArgs As String = "\b\w+_(AfterLabelEdit|BeforeLabelEdit)\((ByVal\ssender\sAs\sObject\,\sByVal\se\sAs\sSystem\.Windows\.Forms\.LabelEditEventArgs\)|sender\sAs\sObject\,\se\sAs\sSystem\.Windows\.Forms\.LabelEditEventArgs\)|sender\sAs\sObject\,\se\sAs\sLabelEditEventArgs)\)"

        Dim patternBeginInvoke As String = "\b(\w+.\w+.BeginInvoke|\w+.BeginInvoke|BeginInvoke)\(New\s\w+\(\w+\)\,\sNew\s\w+\(\)\s\{\w+.\w+\(\d\)\.\w+\(\)\}\)"

        Dim patternInputLanguageChangedEventArgs As String = "\b\w+_InputLanguageChanged\((ByVal\ssender\sAs\sObject\,\sByVal\se\sAs\sSystem\.Windows\.Forms\.InputLanguageChangedEventArgs\)|sender\sAs\sObject\,\se\sAs\sSystem\.Windows\.Forms\.InputLanguageChangedEventArgs\)|sender\sAs\sObject\,\se\sAs\sInputLanguageChangedEventArgs)\)"

        Dim patternInputLanguageChangingEventArgs As String = "\b\w+_InputLanguageChanging\((ByVal\ssender\sAs\sObject\,\sByVal\se\sAs\sSystem\.Windows\.Forms\.InputLanguageChangingEventArgs\)|sender\sAs\sObject\,\se\sAs\sSystem\.Windows\.Forms\.InputLanguageChangingEventArgs\)|sender\sAs\sObject\,\se\sAs\sInputLanguageChangingEventArgs)\)"

        Dim patternScrollEventArgs As String = "\b\w+_Scroll\((ByVal\ssender\sAs\sObject\,\sByVal\se\sAs\sSystem\.Windows\.Forms\.ScrollEventArgs\)|sender\sAs\sObject\,\se\sAs\sSystem\.Windows\.Forms\.ScrollEventArgs\)|sender\sAs\sObject\,\se\sAs\sScrollEventArgs)\)"

        Dim patternComponentModelCancelEventArgs As String = "\b\w+_(Validating|HelpButtonClicked|Opening|FileOK|NewWindow)\((ByVal\ssender\sAs\sObject\,\sByVal\se\sAs\sSystem\.ComponentModel\.CancelEventArgs\)|sender\sAs\sObject\,\se\sAs\sSystem\.ComponentModel\.CancelEventArgs\)|sender\sAs\sObject\,\se\sAs\sCancelEventArgs)\)"

        Dim patternMeasureItemEventArgs As String = "\b\w+_MeasureItem\((ByVal\ssender\sAs\sObject\,\sByVal\se\sAs\sSystem\.Windows\.Forms\.MeasureItemEventArgs\)|sender\sAs\sObject\,\se\sAs\sSystem\.Windows\.Forms\.MeasureItemEventArgs\)|sender\sAs\sObject\,\se\sAs\sMeasureItemEventArgs)\)"

        Dim patternListControlConvertEventArgs As String = "\b\w+_Format\((ByVal\ssender\sAs\sObject\,\sByVal\se\sAs\sSystem\.Windows\.Forms\.ListControlConvertEventArgs\)|sender\sAs\sObject\,\se\sAs\sSystem\.Windows\.Forms\.ListControlConvertEventArgs\)|sender\sAs\sObject\,\se\sAs\sListControlConvertEventArgs)\)"

        Dim patternDrawItemEventArgs As String = "\b\w+_DrawItem\((ByVal\ssender\sAs\sObject\,\sByVal\se\sAs\sSystem\.Windows\.Forms\.DrawItemEventArgs\)|sender\sAs\sObject\,\se\sAs\sSystem\.Windows\.Forms\.DrawItemEventArgs\)|sender\sAs\sObject\,\se\sAs\sDrawItemEventArgs)\)"

        Dim patternQueryPageSettingsEventArgs As String = "\b\w+_QueryPageSettings\((ByVal\ssender\sAs\sObject\,\sByVal\se\sAs\sSystem\.Drawing\.Printing\.QueryPageSettingsEventArgs\)|sender\sAs\sObject\,\se\sAs\sSystem\.Drawing\.Printing\.QueryPageSettingsEventArgs\)|sender\sAs\sObject\,\se\sAs\sQueryPageSettingsEventArgs)\)"

        Dim patternPrintPageEventArgs As String = "\b\w+_PrintPage\((ByVal\ssender\sAs\sObject\,\sByVal\se\sAs\sSystem\.Drawing\.Printing\.PrintPageEventArgs\)|sender\sAs\sObject\,\se\sAs\sSystem\.Drawing\.Printing\.PrintPageEventArgs\)|sender\sAs\sObject\,\se\sAs\sPrintPageEventArgs)\)"

        Dim patternPrintEventArgs As String = "\b\w+_(BeginPrint|EndPrint)\((ByVal\ssender\sAs\sObject\,\sByVal\se\sAs\sSystem\.Drawing\.Printing\.PrintEventArgs\)|sender\sAs\sObject\,\se\sAs\sSystem\.Drawing\.Printing\.PrintEventArgs\)|sender\sAs\sObject\,\se\sAs\sPrintEventArgs)\)"

        Dim patternQueryAccessibilityHelpEventArgs As String = "\b\w+_QueryAccessibilityHelp\((ByVal\ssender\sAs\sObject\,\sByVal\se\sAs\sSystem.Windows.Forms.QueryAccessibilityHelpEventArgs\)|sender\sAs\sObject\,\se\sAs\sSystem\.Windows\.Forms\.QueryAccessibilityHelpEventArgs\)|sender\sAs\sObject\,\se\sAs\sQueryAccessibilityHelpEventArgs)\)"

        Dim patternQueryContinueDragEventArgs As String = "\b\w+_QueryContinueDrag\((ByVal\ssender\sAs\sObject\,\sByVal\se\sAs\sSystem.Windows.Forms.QueryContinueDragEventArgs\)|sender\sAs\sObject\,\se\sAs\sSystem\.Windows\.Forms\.QueryContinueDragEventArgs\)|sender\sAs\sObject\,\se\sAs\sQueryContinueDragEventArgs)\)"

        Dim patternCancelEventArgs As String = "\b\w+_Validating\((ByVal\ssender\sAs\sObject\,\sByVal\se\sAs\sSystem\.Windows\.Forms\.CancelEventArgs\)|sender\sAs\sObject\,\se\sAs\sSystem\.Windows\.Forms\.CancelEventArgs\)|sender\sAs\sObject\,\se\sAs\sCancelEventArgs)\)"

        Dim patternFormClosingEventArgs As String = "\b\w+_FormClosing\((ByVal\ssender\sAs\sObject\,\sByVal\se\sAs\sSystem\.Windows\.Forms\.FormClosingEventArgs\)|sender\sAs\sObject\,\se\sAs\sSystem\.Windows\.Forms\.FormClosingEventArgs\)|sender\sAs\sObject\,\se\sAs\sFormClosingEventArgs)\)"

        Dim patternFormClosedEventArgs As String = "\b\w+_FormClosed\((ByVal\ssender\sAs\sObject\,\sByVal\se\sAs\sSystem\.Windows\.Forms\.FormClosedEventArgs\)|sender\sAs\sObject\,\se\sAs\sSystem\.Windows\.Forms\.FormClosedEventArgs\)|sender\sAs\sObject\,\se\sAs\sFormClosedEventArgs)\)"

        Dim patternPreviewKeyDownEventArgs As String = "\b\w+_PreviewKeyDown\((ByVal\ssender\sAs\sObject\,\sByVal\se\sAs\sSystem\.Windows\.Forms\.PreviewKeyDownEventArgs\)|sender\sAs\sObject\,\se\sAs\sSystem\.Windows\.Forms\.PreviewKeyDownEventArgs\)|sender\sAs\sObject\,\se\sAs\sPreviewKeyDownEventArgs)\)"

        Dim patternPaintEventArgs As String = "\b\w+_(Paint|PaintGrip)\((ByVal\ssender\sAs\sObject\,|sender\sAs\sObject\,)\s(ByVal\se\sAs\sSystem\.Windows\.Forms\.PaintEventArgs\)|e\sAs\sSystem\.Windows\.Forms\.PaintEventArgs|e\sAs\sPaintEventArgs)\)"

        Dim patternLayoutEventArgs As String = "\b\w+_HelpRequested\((ByVal\ssender\sAs\sObject\,\sByVal\se\sAs\sSystem\.Windows\.Forms\.LayoutEventArgs\)|sender\sAs\sObject\,\se\sAs\sSystem\.Windows\.Forms\.LayoutEventArgs\)|sender\sAs\sObject\,\se\sAs\sLayoutEventArgs)\)"

        Dim patternControlAddedRemoved As String = "\b\w+_(ControlAdded|ControlRemoved)\((ByVal\ssender\sAs\sObject\,\sByVal\se\sAs\sSystem\.Windows\.Forms\.ControlEventArgs\)|sender\sAs\sObject\,\se\sAs\sSystem\.Windows\.Forms\.ControlEventArgs\)|sender\sAs\sObject\,\se\sAs\sControlEventArgs)\)"

        Dim patternChangeUICues As String = "\b\w+_ChangeUICues\((ByVal\ssender\sAs\sObject\,\sByVal\se\sAs\sSystem\.Window\s.Forms\.UICuesEventArgs\)|sender\sAs\sObject\,\se\sAs\sSystem\.Windows\.Forms\.UICuesEventArgs\)|sender\sAs\sObject\,\se\sAs\sUICuesEventArgs)\)"

        Dim patternGiveFeedback As String = "\b\w+_GiveFeedback\((ByVal\ssender\sAs\sObject\,\sByVal\se\sAs\sSystem\.Windows\.Forms\.GiveFeedbackEventArgs\)|sender\sAs\sObject\,\se\sAs\sSystem\.Windows\.Forms\.GiveFeedbackEventArgs\)|sender\sAs\sObject\,\se\sAs\sGiveFeedbackEventArgs)\)"

        Dim patternHelpRequested As String = "\b\w+_HelpRequested\((ByVal\ssender\sAs\sObject\,\sByVal\shlpevent\sAs\sSystem\.Windows\.Forms\.HelpEventArgs\)|sender\sAs\sObject\,\shlpevent\sAs\sSystem\.Windows\.Forms\.HelpEventArgs\)|sender\sAs\sObject\,\shlpevent\sAs\sHelpEventArgs)\)"

        Dim patternInvalidated As String = "\b\w+_Invalidated\((ByVal\ssender\sAs\sObject\,\sByVal\se\sAs\sSystem\.Windows\.Forms\.InvalidateEventArgs\)|sender\sAs\sObject\,\se\sAs\sSystem\.Windows\.Forms\.InvalidateEventArgs\)|sender\sAs\sObject\,\se\sAs\sInvalidateEventArgs)\)"

        Dim patternCheckChanged As String = "\b\w+_CheckChanged\((ByVal\ssender\sAs\sObject\,\sByVal\se\sAs\sSystem\.Windows\.Forms\.CheckChangedEventArgs\)|sender\sAs\sObject\,\se\sAs\sSystem\.Windows\.Forms\.CheckChangedEventArgs\)|sender\sAs\sObject\,\se\sAs\sCheckChangedEventArgs)\)"

        Dim patternBackgroundWorker As String = "\b\w+_(DoWork|ProgressChanged|RunWorkerCompleted)\((ByVal\ssender\sAs\sObject\,\sByVal\se\sAs\sSystem\.ComponentModel\.(DoWorkEventArgs|ProgressChangedEventArgs|RunWorkerCompletedEventArgs)\)|sender\sAs\sObject\,\se\sAs\sSystem\.ComponentModel\.(DoWorkEventArgs|ProgressChangedEventArgs|RunWorkerCompletedEventArgs))\)"

        Dim patternMouseEventArgs As String = "\b\w+_(MouseUp|MouseDown|MouseMove|MouseWheel|MouseDoubleClick)\((ByVal\ssender\sAs\sObject\,\sByVal\se\sAs\sMouseEventArgs\)|sender\sAs\sObject\,\se\sAs\sMouseEventArgs)\)"

        Dim patternKeysUpDown As String = "\b\w+_(KeyUp|KeyDown)\((ByVal\ssender\sAs\sObject\,\sByVal\se\sAs\sSystem\.Windows\.Forms\.KeyEventArgs\)|sender\sAs\sObject\,\se\sAs\sSystem\.Windows\.Forms\.KeyEventArgs\)|sender\sAs\sObject\,\se\sAs\sKeyEventArgs)\)"

        Dim patternKeyPress As String = "\b\w+_KeyPress\(ByVal\ssender\sAs\sObject\,\sByVal\se\sAs\s(System\.Windows\.Forms\.KeyPressEventArgs|KeyPressEventArgs)\)|sender\sAs\sObject\,\se\sAs\s(System\.Windows\.Forms\.KeyPressEventArgs|KeyPressEventArgs)\)"

        Dim patternDragDropEnter As String = "\b\w+_(DragDrop|DragEnter|DragOver)\((ByVal\ssender\sAs\sObject\,\sByVal\se\sAs\sSystem\.Windows\.Forms\.DragEventArgs\)|sender\sAs\sObject\,\se\sAs\sSystem\.Windows\.Forms\.DragEventArgs\)|sender\sAs\sObject\,\se\sAs\sDragEventArgs)\)"


        'Splitting HeadAches...
        Dim parts() As String
        Dim parts1() As String
        Dim strMatch2 As String

        ' DirectCast, CType fix.
        txtVBNetText = Replace(txtVBNetText, "DirectCast", "CType")

        ' var Fix, We change this latter in code below!
        txtVBNetText = Regex.Replace(txtVBNetText, "As var\b", "As Object", RegexOptions.IgnoreCase)

        ' Module fix.
        If Regex.IsMatch(txtVBNetText, "\bShared Class ", RegexOptions.IgnoreCase) Then
            txtVBNetText = Regex.Replace(txtVBNetText, "\bShared Class ", "Module ", RegexOptions.IgnoreCase)
            txtVBNetText = Regex.Replace(txtVBNetText, "\bShared ", " ", RegexOptions.IgnoreCase)
        End If

        ' Is Nothing, IsNot Nothing fix. 
        txtVBNetText = Regex.Replace(txtVBNetText, "= Nothing\b", "Is Nothing", RegexOptions.IgnoreCase)
        txtVBNetText = Regex.Replace(txtVBNetText, "<> Nothing\b", "IsNot Nothing", RegexOptions.IgnoreCase)
        txtVBNetText = Regex.Replace(txtVBNetText, "New ThreadStart\((?!AddressOf\b)", "New ThreadStart(AddressOf ", RegexOptions.IgnoreCase)

        ' BeginInvoke, AddressOf fix.   'BeginInvoke(New DroppedFileHandler(FilterZip), New Object() {arr.GetValue(0).ToString()})
        For Each m In Regex.Matches(txtVBNetText, patternBeginInvoke, RegexOptions.IgnoreCase)
            strMatch = m.Value
            parts = strMatch.Split(",")
            parts1 = parts(0).Split("(")
            txtVBNetText = Replace(txtVBNetText, strMatch, parts1(0) & "(" & parts1(1) & "(AddressOf " & parts1(2) & ", " & parts(1))
            strMatch = String.Empty
        Next

        ' AddHandler, AddressOf fix.   
        For Each m In Regex.Matches(txtVBNetText, regexStr, RegexOptions.IgnoreCase Or RegexOptions.Multiline)
            strMatch = m.Value
            parts = strMatch.Split(" ")
            parts1 = parts(3).Split("(")
            txtVBNetText = Replace(txtVBNetText, strMatch, "AddHandler " & parts(0) & _
                                   ", New " & parts1(0) & "(AddressOf(" & parts1(1) & ")")
            strMatch = String.Empty
        Next

        'playContextMenuStrip1.Items[contextMenuCount + i].MouseDown += new MouseEventHandler(PlayMenu_MouseDown)
        'playContextMenuStrip1.Items[i + 2].MouseDown += new MouseEventHandler(PlayMenu_MouseDown)
        ' AddHandler, AddressOf fix #2.
        Dim parts2() As String
        For Each m In Regex.Matches(txtVBNetText, regexStr2, RegexOptions.IgnoreCase Or RegexOptions.Multiline)
            strMatch = m.Value
            parts = strMatch.Split(".")
            parts1 = parts(2).Split(" ")
            parts2 = parts1(3).Split("(")
            txtVBNetText = Replace(txtVBNetText, strMatch, "AddHandler " & parts(0) & "." & parts(1) & "." & _
                                   parts1(0) & ", " & "New " & parts2(0) & "(AddressOf(" & parts2(1))
            strMatch = String.Empty
        Next

        ' RemoveHandler, AddressOf fix.
        For Each m In Regex.Matches(txtVBNetText, remregexStr, RegexOptions.IgnoreCase Or RegexOptions.Multiline)
            strMatch = m.Value
            parts = strMatch.Split(" ")
            parts1 = parts(3).Split("(")
            txtVBNetText = Replace(txtVBNetText, strMatch, "RemoveHandler " & parts(0) & _
                                   ", New " & parts1(0) & "(AddressOf(" & parts1(1) & ")")
            strMatch = String.Empty
        Next

        ' RemoveHandler, AddressOf fix. \w+_\w+\.\w+\s\-\=\s\w+_\w+
        For Each m In Regex.Matches(txtVBNetText, remregexStr2, RegexOptions.IgnoreCase Or RegexOptions.Multiline)
            strMatch = m.Value
            parts = strMatch.Split(" ")
            txtVBNetText = Replace(txtVBNetText, strMatch, "RemoveHandler " & parts(0) & _
                                   ", " & "AddressOf(" & parts(2) & ")")
            strMatch = String.Empty
        Next

        'If var is Integer fix
        For Each m In Regex.Matches(txtVBNetText, patternIsInteger, RegexOptions.IgnoreCase Or RegexOptions.Multiline)
            strMatch = m.Value
            strMatch2 = strMatch
            strMatch = strMatch.Replace(" ", ",")
            strMatch = strMatch & ","
            parts = strMatch.Split(",")

            txtVBNetText = Replace(txtVBNetText, strMatch2, "As Integer = " & parts(3), RegexOptions.IgnoreCase)

            strMatch = String.Empty
        Next

        'If var is Class fix
        For Each m In Regex.Matches(txtVBNetText, patternClass, RegexOptions.IgnoreCase Or RegexOptions.Multiline)
            strMatch = m.Value
            strMatch2 = strMatch
            strMatch = strMatch.Replace(" ", ",")
            strMatch = strMatch & ","
            strMatch = strMatch.Replace("()", "")

            parts = strMatch.Split(",")

            txtVBNetText = Replace(txtVBNetText, strMatch2, "As " & parts(4) & " = New " & parts(4) & "()", RegexOptions.IgnoreCase)

            strMatch = String.Empty
        Next

        'As var = TryCast(e.Argument, VariableGoesHere) fix
        For Each m In Regex.Matches(txtVBNetText, patternTryCast, RegexOptions.IgnoreCase Or RegexOptions.Multiline)
            strMatch = m.Value
            strMatch2 = strMatch
            strMatch = strMatch.Replace(",", "")
            strMatch = strMatch.Replace(" ", ",")
            strMatch = strMatch.Replace(")", "")
            strMatch = strMatch & ","

            parts = strMatch.Split(",")

            txtVBNetText = Replace(txtVBNetText, strMatch2, "As " & parts(4) & " = TryCast(e.Argument, " & parts(4) & ")", RegexOptions.IgnoreCase)

            strMatch = String.Empty
        Next

        'Handles System.EventArgs fix
        For Each m In Regex.Matches(txtVBNetText, patternSystemEventArgs, RegexOptions.IgnoreCase Or RegexOptions.Multiline)
            strMatch = m.Value
            strMatch2 = strMatch
            strMatch = strMatch.Replace("(", " ")
            strMatch = strMatch.Replace("_", " ")
            strMatch = strMatch.Replace(" ", ",")

            parts = strMatch.Split(",")

            txtVBNetText = Replace(txtVBNetText, strMatch2, parts(0) & "_" & parts(1) & _
                                   "(sender As Object, e As System.EventArgs) Handles " & _
                                   parts(0) & "." & parts(1), RegexOptions.IgnoreCase)

            strMatch = String.Empty
        Next

        'Handles DataGridViewRowCancelEventArgs fix
        For Each m In Regex.Matches(txtVBNetText, patternDataGridViewRowCancelEventArgs, RegexOptions.IgnoreCase Or RegexOptions.Multiline)
            strMatch = m.Value
            strMatch2 = strMatch
            strMatch = strMatch.Replace("(", " ")
            strMatch = strMatch.Replace("_", " ")
            strMatch = strMatch.Replace(" ", ",")

            parts = strMatch.Split(",")

            txtVBNetText = Replace(txtVBNetText, strMatch2, parts(0) & "_" & parts(1) & _
                                   "(sender As Object, e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles " & _
                                   parts(0) & "." & parts(1), RegexOptions.IgnoreCase)

            strMatch = String.Empty
        Next

        'Handles DataGridViewSortCompareEventArgs fix
        For Each m In Regex.Matches(txtVBNetText, patternDataGridViewSortCompareEventArgs, RegexOptions.IgnoreCase Or RegexOptions.Multiline)
            strMatch = m.Value
            strMatch2 = strMatch
            strMatch = strMatch.Replace("(", " ")
            strMatch = strMatch.Replace("_", " ")
            strMatch = strMatch.Replace(" ", ",")

            parts = strMatch.Split(",")

            txtVBNetText = Replace(txtVBNetText, strMatch2, parts(0) & "_" & parts(1) & _
                                   "(sender As Object, e As System.Windows.Forms.DataGridViewSortCompareEventArgs) Handles " & _
                                   parts(0) & "." & parts(1), RegexOptions.IgnoreCase)

            strMatch = String.Empty
        Next

        'Handles DataGridViewRowStateChangedEventArgs fix
        For Each m In Regex.Matches(txtVBNetText, patternDataGridViewRowStateChangedEventArgs, RegexOptions.IgnoreCase Or RegexOptions.Multiline)
            strMatch = m.Value
            strMatch2 = strMatch
            strMatch = strMatch.Replace("(", " ")
            strMatch = strMatch.Replace("_", " ")
            strMatch = strMatch.Replace(" ", ",")

            parts = strMatch.Split(",")

            txtVBNetText = Replace(txtVBNetText, strMatch2, parts(0) & "_" & parts(1) & _
                                   "(sender As Object, e As System.Windows.Forms.DataGridViewRowStateChangedEventArgs) Handles " & _
                                   parts(0) & "." & parts(1), RegexOptions.IgnoreCase)

            strMatch = String.Empty
        Next

        'Handles DataGridViewRowsRemovedEventArgs fix
        For Each m In Regex.Matches(txtVBNetText, patternDataGridViewRowsRemovedEventArgs, RegexOptions.IgnoreCase Or RegexOptions.Multiline)
            strMatch = m.Value
            strMatch2 = strMatch
            strMatch = strMatch.Replace("(", " ")
            strMatch = strMatch.Replace("_", " ")
            strMatch = strMatch.Replace(" ", ",")

            parts = strMatch.Split(",")

            txtVBNetText = Replace(txtVBNetText, strMatch2, parts(0) & "_" & parts(1) & _
                                   "(sender As Object, e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles " & _
                                   parts(0) & "." & parts(1), RegexOptions.IgnoreCase)

            strMatch = String.Empty
        Next

        'Handles DataGridViewRowsAddedEventArgs fix
        For Each m In Regex.Matches(txtVBNetText, patternDataGridViewRowsAddedEventArgs, RegexOptions.IgnoreCase Or RegexOptions.Multiline)
            strMatch = m.Value
            strMatch2 = strMatch
            strMatch = strMatch.Replace("(", " ")
            strMatch = strMatch.Replace("_", " ")
            strMatch = strMatch.Replace(" ", ",")

            parts = strMatch.Split(",")

            txtVBNetText = Replace(txtVBNetText, strMatch2, parts(0) & "_" & parts(1) & _
                                   "(sender As Object, e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles " & _
                                   parts(0) & "." & parts(1), RegexOptions.IgnoreCase)

            strMatch = String.Empty
        Next

        'Handles DataGridViewRowPrePaintEventArgs fix
        For Each m In Regex.Matches(txtVBNetText, patternDataGridViewRowPrePaintEventArgs, RegexOptions.IgnoreCase Or RegexOptions.Multiline)
            strMatch = m.Value
            strMatch2 = strMatch
            strMatch = strMatch.Replace("(", " ")
            strMatch = strMatch.Replace("_", " ")
            strMatch = strMatch.Replace(" ", ",")

            parts = strMatch.Split(",")

            txtVBNetText = Replace(txtVBNetText, strMatch2, parts(0) & "_" & parts(1) & _
                                   "(sender As Object, e As System.Windows.Forms.DataGridViewRowPrePaintEventArgs) Handles " & _
                                   parts(0) & "." & parts(1), RegexOptions.IgnoreCase)

            strMatch = String.Empty
        Next

        'Handles DataGridViewRowPostPaintEventArgs fix
        For Each m In Regex.Matches(txtVBNetText, patternDataGridViewRowPostPaintEventArgs, RegexOptions.IgnoreCase Or RegexOptions.Multiline)
            strMatch = m.Value
            strMatch2 = strMatch
            strMatch = strMatch.Replace("(", " ")
            strMatch = strMatch.Replace("_", " ")
            strMatch = strMatch.Replace(" ", ",")

            parts = strMatch.Split(",")

            txtVBNetText = Replace(txtVBNetText, strMatch2, parts(0) & "_" & parts(1) & _
                                   "(sender As Object, e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles " & _
                                   parts(0) & "." & parts(1), RegexOptions.IgnoreCase)

            strMatch = String.Empty
        Next

        'Handles DataGridViewRowHeightInfoPushedEventArgs fix
        For Each m In Regex.Matches(txtVBNetText, patternDataGridViewRowHeightInfoPushedEventArgs, RegexOptions.IgnoreCase Or RegexOptions.Multiline)
            strMatch = m.Value
            strMatch2 = strMatch
            strMatch = strMatch.Replace("(", " ")
            strMatch = strMatch.Replace("_", " ")
            strMatch = strMatch.Replace(" ", ",")

            parts = strMatch.Split(",")

            txtVBNetText = Replace(txtVBNetText, strMatch2, parts(0) & "_" & parts(1) & _
                                   "(sender As Object, e As System.Windows.Forms.DataGridViewRowHeightInfoPushedEventArgs) Handles " & _
                                   parts(0) & "." & parts(1), RegexOptions.IgnoreCase)

            strMatch = String.Empty
        Next

        'Handles DataGridViewRowHeightInfoNeededEventArgs fix
        For Each m In Regex.Matches(txtVBNetText, patternDataGridViewRowHeightInfoNeededEventArgs, RegexOptions.IgnoreCase Or RegexOptions.Multiline)
            strMatch = m.Value
            strMatch2 = strMatch
            strMatch = strMatch.Replace("(", " ")
            strMatch = strMatch.Replace("_", " ")
            strMatch = strMatch.Replace(" ", ",")

            parts = strMatch.Split(",")

            txtVBNetText = Replace(txtVBNetText, strMatch2, parts(0) & "_" & parts(1) & _
                                   "(sender As Object, e As System.Windows.Forms.DataGridViewRowHeightInfoNeededEventArgs) Handles " & _
                                   parts(0) & "." & parts(1), RegexOptions.IgnoreCase)

            strMatch = String.Empty
        Next

        'Handles DataGridViewRowErrorTextNeededEventArgs fix
        For Each m In Regex.Matches(txtVBNetText, patternDataGridViewRowErrorTextNeededEventArgs, RegexOptions.IgnoreCase Or RegexOptions.Multiline)
            strMatch = m.Value
            strMatch2 = strMatch
            strMatch = strMatch.Replace("(", " ")
            strMatch = strMatch.Replace("_", " ")
            strMatch = strMatch.Replace(" ", ",")

            parts = strMatch.Split(",")

            txtVBNetText = Replace(txtVBNetText, strMatch2, parts(0) & "_" & parts(1) & _
                                   "(sender As Object, e As System.Windows.Forms.DataGridViewRowErrorTextNeededEventArgs) Handles " & _
                                   parts(0) & "." & parts(1), RegexOptions.IgnoreCase)

            strMatch = String.Empty
        Next

        'Handles DataGridViewRowDividerDoubleClickEventArgs fix
        For Each m In Regex.Matches(txtVBNetText, patternDataGridViewRowDividerDoubleClickEventArgs, RegexOptions.IgnoreCase Or RegexOptions.Multiline)
            strMatch = m.Value
            strMatch2 = strMatch
            strMatch = strMatch.Replace("(", " ")
            strMatch = strMatch.Replace("_", " ")
            strMatch = strMatch.Replace(" ", ",")

            parts = strMatch.Split(",")

            txtVBNetText = Replace(txtVBNetText, strMatch2, parts(0) & "_" & parts(1) & _
                                   "(sender As Object, e As System.Windows.Forms.DataGridViewRowDividerDoubleClickEventArgs) Handles " & _
                                   parts(0) & "." & parts(1), RegexOptions.IgnoreCase)

            strMatch = String.Empty
        Next

        'Handles DataGridViewRowContextMenuStripNeededEventArgs fix
        For Each m In Regex.Matches(txtVBNetText, patternDataGridViewRowContextMenuStripNeededEventArgs, RegexOptions.IgnoreCase Or RegexOptions.Multiline)
            strMatch = m.Value
            strMatch2 = strMatch
            strMatch = strMatch.Replace("(", " ")
            strMatch = strMatch.Replace("_", " ")
            strMatch = strMatch.Replace(" ", ",")

            parts = strMatch.Split(",")

            txtVBNetText = Replace(txtVBNetText, strMatch2, parts(0) & "_" & parts(1) & _
                                   "(sender As Object, e As System.Windows.Forms.DataGridViewRowContextMenuStripNeededEventArgs) Handles " & _
                                   parts(0) & "." & parts(1), RegexOptions.IgnoreCase)

            strMatch = String.Empty
        Next

        'Handles DataGridViewRowEventArgs fix
        For Each m In Regex.Matches(txtVBNetText, patternDataGridViewRowEventArgs, RegexOptions.IgnoreCase Or RegexOptions.Multiline)
            strMatch = m.Value
            strMatch2 = strMatch
            strMatch = strMatch.Replace("(", " ")
            strMatch = strMatch.Replace("_", " ")
            strMatch = strMatch.Replace(" ", ",")

            parts = strMatch.Split(",")

            txtVBNetText = Replace(txtVBNetText, strMatch2, parts(0) & "_" & parts(1) & _
                                   "(sender As Object, e As System.Windows.Forms.DataGridViewRowEventArgs) Handles " & _
                                   parts(0) & "." & parts(1), RegexOptions.IgnoreCase)

            strMatch = String.Empty
        Next

        'Handles DataGridViewEditingControlShowingEventArgs fix
        For Each m In Regex.Matches(txtVBNetText, patternDataGridViewEditingControlShowingEventArgs, RegexOptions.IgnoreCase Or RegexOptions.Multiline)
            strMatch = m.Value
            strMatch2 = strMatch
            strMatch = strMatch.Replace("(", " ")
            strMatch = strMatch.Replace("_", " ")
            strMatch = strMatch.Replace(" ", ",")

            parts = strMatch.Split(",")

            txtVBNetText = Replace(txtVBNetText, strMatch2, parts(0) & "_" & parts(1) & _
                                   "(sender As Object, e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles " & _
                                   parts(0) & "." & parts(1), RegexOptions.IgnoreCase)

            strMatch = String.Empty
        Next

        'Handles DataGridViewDataErrorEventArgs fix
        For Each m In Regex.Matches(txtVBNetText, patternDataGridViewDataErrorEventArgs, RegexOptions.IgnoreCase Or RegexOptions.Multiline)
            strMatch = m.Value
            strMatch2 = strMatch
            strMatch = strMatch.Replace("(", " ")
            strMatch = strMatch.Replace("_", " ")
            strMatch = strMatch.Replace(" ", ",")

            parts = strMatch.Split(",")

            txtVBNetText = Replace(txtVBNetText, strMatch2, parts(0) & "_" & parts(1) & _
                                   "(sender As Object, e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles " & _
                                   parts(0) & "." & parts(1), RegexOptions.IgnoreCase)

            strMatch = String.Empty
        Next

        'Handles DataGridViewBindingCompleteEventArgs fix
        For Each m In Regex.Matches(txtVBNetText, patternDataGridViewBindingCompleteEventArgs, RegexOptions.IgnoreCase Or RegexOptions.Multiline)
            strMatch = m.Value
            strMatch2 = strMatch
            strMatch = strMatch.Replace("(", " ")
            strMatch = strMatch.Replace("_", " ")
            strMatch = strMatch.Replace(" ", ",")

            parts = strMatch.Split(",")

            txtVBNetText = Replace(txtVBNetText, strMatch2, parts(0) & "_" & parts(1) & _
                                   "(sender As Object, e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs) Handles " & _
                                   parts(0) & "." & parts(1), RegexOptions.IgnoreCase)

            strMatch = String.Empty
        Next

        'Handles DataGridViewColumnStateChangedEventArgs fix
        For Each m In Regex.Matches(txtVBNetText, patternDataGridViewColumnStateChangedEventArgs, RegexOptions.IgnoreCase Or RegexOptions.Multiline)
            strMatch = m.Value
            strMatch2 = strMatch
            strMatch = strMatch.Replace("(", " ")
            strMatch = strMatch.Replace("_", " ")
            strMatch = strMatch.Replace(" ", ",")

            parts = strMatch.Split(",")

            txtVBNetText = Replace(txtVBNetText, strMatch2, parts(0) & "_" & parts(1) & _
                                   "(sender As Object, e As System.Windows.Forms.DataGridViewColumnStateChangedEventArgs) Handles " & _
                                   parts(0) & "." & parts(1), RegexOptions.IgnoreCase)

            strMatch = String.Empty
        Next

        'Handles DataGridViewAutoSizeModeEventArgs fix
        For Each m In Regex.Matches(txtVBNetText, patternDataGridViewAutoSizeModeEventArgs, RegexOptions.IgnoreCase Or RegexOptions.Multiline)
            strMatch = m.Value
            strMatch2 = strMatch
            strMatch = strMatch.Replace("(", " ")
            strMatch = strMatch.Replace("_", " ")
            strMatch = strMatch.Replace(" ", ",")

            parts = strMatch.Split(",")

            txtVBNetText = Replace(txtVBNetText, strMatch2, parts(0) & "_" & parts(1) & _
                                   "(sender As Object, e As System.Windows.Forms.DataGridViewAutoSizeModeEventArgs) Handles " & _
                                   parts(0) & "." & parts(1), RegexOptions.IgnoreCase)

            strMatch = String.Empty
        Next

        'Handles DataGridViewColumnEventArgs fix
        For Each m In Regex.Matches(txtVBNetText, patternDataGridViewColumnEventArgs, RegexOptions.IgnoreCase Or RegexOptions.Multiline)
            strMatch = m.Value
            strMatch2 = strMatch
            strMatch = strMatch.Replace("(", " ")
            strMatch = strMatch.Replace("_", " ")
            strMatch = strMatch.Replace(" ", ",")

            parts = strMatch.Split(",")

            txtVBNetText = Replace(txtVBNetText, strMatch2, parts(0) & "_" & parts(1) & _
                                   "(sender As Object, e As System.Windows.Forms.DataGridViewColumnEventArgs) Handles " & _
                                   parts(0) & "." & parts(1), RegexOptions.IgnoreCase)

            strMatch = String.Empty
        Next

        'Handles DataGridViewCellValueEventArgs fix
        For Each m In Regex.Matches(txtVBNetText, patternDataGridViewCellValueEventArgs, RegexOptions.IgnoreCase Or RegexOptions.Multiline)
            strMatch = m.Value
            strMatch2 = strMatch
            strMatch = strMatch.Replace("(", " ")
            strMatch = strMatch.Replace("_", " ")
            strMatch = strMatch.Replace(" ", ",")

            parts = strMatch.Split(",")

            txtVBNetText = Replace(txtVBNetText, strMatch2, parts(0) & "_" & parts(1) & _
                                   "(sender As Object, e As System.Windows.Forms.DataGridViewCellValueEventArgs) Handles " & _
                                   parts(0) & "." & parts(1), RegexOptions.IgnoreCase)

            strMatch = String.Empty
        Next

        'Handles DataGridViewCellValidatingEventArgs fix
        For Each m In Regex.Matches(txtVBNetText, patternDataGridViewCellValidatingEventArgs, RegexOptions.IgnoreCase Or RegexOptions.Multiline)
            strMatch = m.Value
            strMatch2 = strMatch
            strMatch = strMatch.Replace("(", " ")
            strMatch = strMatch.Replace("_", " ")
            strMatch = strMatch.Replace(" ", ",")

            parts = strMatch.Split(",")

            txtVBNetText = Replace(txtVBNetText, strMatch2, parts(0) & "_" & parts(1) & _
                                   "(sender As Object, e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles " & _
                                   parts(0) & "." & parts(1), RegexOptions.IgnoreCase)

            strMatch = String.Empty
        Next

        'Handles DataGridViewCellToolTipTextNeededEventArgs fix
        For Each m In Regex.Matches(txtVBNetText, patternDataGridViewCellToolTipTextNeededEventArgs, RegexOptions.IgnoreCase Or RegexOptions.Multiline)
            strMatch = m.Value
            strMatch2 = strMatch
            strMatch = strMatch.Replace("(", " ")
            strMatch = strMatch.Replace("_", " ")
            strMatch = strMatch.Replace(" ", ",")

            parts = strMatch.Split(",")

            txtVBNetText = Replace(txtVBNetText, strMatch2, parts(0) & "_" & parts(1) & _
                                   "(sender As Object, e As System.Windows.Forms.DataGridViewCellToolTipTextNeededEventArgs) Handles " & _
                                   parts(0) & "." & parts(1), RegexOptions.IgnoreCase)

            strMatch = String.Empty
        Next

        'Handles DataGridViewCellStyleContentChangedEventArgs fix
        For Each m In Regex.Matches(txtVBNetText, patternDataGridViewCellStyleContentChangedEventArgs, RegexOptions.IgnoreCase Or RegexOptions.Multiline)
            strMatch = m.Value
            strMatch2 = strMatch
            strMatch = strMatch.Replace("(", " ")
            strMatch = strMatch.Replace("_", " ")
            strMatch = strMatch.Replace(" ", ",")

            parts = strMatch.Split(",")

            txtVBNetText = Replace(txtVBNetText, strMatch2, parts(0) & "_" & parts(1) & _
                                   "(sender As Object, e As System.Windows.Forms.DataGridViewCellStyleContentChangedEventArgs) Handles " & _
                                   parts(0) & "." & parts(1), RegexOptions.IgnoreCase)

            strMatch = String.Empty
        Next

        'Handles DataGridViewCellStateChangedEventArgs fix
        For Each m In Regex.Matches(txtVBNetText, patternDataGridViewCellStateChangedEventArgs, RegexOptions.IgnoreCase Or RegexOptions.Multiline)
            strMatch = m.Value
            strMatch2 = strMatch
            strMatch = strMatch.Replace("(", " ")
            strMatch = strMatch.Replace("_", " ")
            strMatch = strMatch.Replace(" ", ",")

            parts = strMatch.Split(",")

            txtVBNetText = Replace(txtVBNetText, strMatch2, parts(0) & "_" & parts(1) & _
                                   "(sender As Object, e As System.Windows.Forms.DataGridViewCellStateChangedEventArgs) Handles " & _
                                   parts(0) & "." & parts(1), RegexOptions.IgnoreCase)

            strMatch = String.Empty
        Next

        'Handles DataGridViewCellParsingEventArgs fix
        For Each m In Regex.Matches(txtVBNetText, patternDataGridViewCellParsingEventArgs, RegexOptions.IgnoreCase Or RegexOptions.Multiline)
            strMatch = m.Value
            strMatch2 = strMatch
            strMatch = strMatch.Replace("(", " ")
            strMatch = strMatch.Replace("_", " ")
            strMatch = strMatch.Replace(" ", ",")

            parts = strMatch.Split(",")

            txtVBNetText = Replace(txtVBNetText, strMatch2, parts(0) & "_" & parts(1) & _
                                   "(sender As Object, e As System.Windows.Forms.DataGridViewCellParsingEventArgs) Handles " & _
                                   parts(0) & "." & parts(1), RegexOptions.IgnoreCase)

            strMatch = String.Empty
        Next

        'Handles DataGridViewCellPaintingEventArgs fix
        For Each m In Regex.Matches(txtVBNetText, patternDataGridViewCellPaintingEventArgs, RegexOptions.IgnoreCase Or RegexOptions.Multiline)
            strMatch = m.Value
            strMatch2 = strMatch
            strMatch = strMatch.Replace("(", " ")
            strMatch = strMatch.Replace("_", " ")
            strMatch = strMatch.Replace(" ", ",")

            parts = strMatch.Split(",")

            txtVBNetText = Replace(txtVBNetText, strMatch2, parts(0) & "_" & parts(1) & _
                                   "(sender As Object, e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles " & _
                                   parts(0) & "." & parts(1), RegexOptions.IgnoreCase)

            strMatch = String.Empty
        Next

        'Handles DataGridViewCellMouseEventArgs fix
        For Each m In Regex.Matches(txtVBNetText, patternDataGridViewCellMouseEventArgs, RegexOptions.IgnoreCase Or RegexOptions.Multiline)
            strMatch = m.Value
            strMatch2 = strMatch
            strMatch = strMatch.Replace("(", " ")
            strMatch = strMatch.Replace("_", " ")
            strMatch = strMatch.Replace(" ", ",")

            parts = strMatch.Split(",")

            txtVBNetText = Replace(txtVBNetText, strMatch2, parts(0) & "_" & parts(1) & _
                                   "(sender As Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles " & _
                                   parts(0) & "." & parts(1), RegexOptions.IgnoreCase)

            strMatch = String.Empty
        Next

        'Handles DataGridViewCellFormattingEventArgs fix
        For Each m In Regex.Matches(txtVBNetText, patternDataGridViewCellFormattingEventArgs, RegexOptions.IgnoreCase Or RegexOptions.Multiline)
            strMatch = m.Value
            strMatch2 = strMatch
            strMatch = strMatch.Replace("(", " ")
            strMatch = strMatch.Replace("_", " ")
            strMatch = strMatch.Replace(" ", ",")

            parts = strMatch.Split(",")

            txtVBNetText = Replace(txtVBNetText, strMatch2, parts(0) & "_" & parts(1) & _
                                   "(sender As Object, e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles " & _
                                   parts(0) & "." & parts(1), RegexOptions.IgnoreCase)

            strMatch = String.Empty
        Next

        'Handles DataGridViewCellErrorTextNeededEventArgs fix
        For Each m In Regex.Matches(txtVBNetText, patternDataGridViewCellErrorTextNeededEventArgs, RegexOptions.IgnoreCase Or RegexOptions.Multiline)
            strMatch = m.Value
            strMatch2 = strMatch
            strMatch = strMatch.Replace("(", " ")
            strMatch = strMatch.Replace("_", " ")
            strMatch = strMatch.Replace(" ", ",")

            parts = strMatch.Split(",")

            txtVBNetText = Replace(txtVBNetText, strMatch2, parts(0) & "_" & parts(1) & _
                                   "(sender As Object, e As System.Windows.Forms.DataGridViewCellErrorTextNeededEventArgs) Handles " & _
                                   parts(0) & "." & parts(1), RegexOptions.IgnoreCase)

            strMatch = String.Empty
        Next

        'Handles DataGridViewCellContextMenuStripNeededEventArgs fix
        For Each m In Regex.Matches(txtVBNetText, patternDataGridViewCellContextMenuStripNeededEventArgs, RegexOptions.IgnoreCase Or RegexOptions.Multiline)
            strMatch = m.Value
            strMatch2 = strMatch
            strMatch = strMatch.Replace("(", " ")
            strMatch = strMatch.Replace("_", " ")
            strMatch = strMatch.Replace(" ", ",")

            parts = strMatch.Split(",")

            txtVBNetText = Replace(txtVBNetText, strMatch2, parts(0) & "_" & parts(1) & _
                                   "(sender As Object, e As System.Windows.Forms.DataGridViewCellContextMenuStripNeededEventArgs) Handles " & _
                                   parts(0) & "." & parts(1), RegexOptions.IgnoreCase)

            strMatch = String.Empty
        Next

        'Handles DataGridViewCellEventArgs fix
        For Each m In Regex.Matches(txtVBNetText, patternDataGridViewCellEventArgs, RegexOptions.IgnoreCase Or RegexOptions.Multiline)
            strMatch = m.Value
            strMatch2 = strMatch
            strMatch = strMatch.Replace("(", " ")
            strMatch = strMatch.Replace("_", " ")
            strMatch = strMatch.Replace(" ", ",")

            parts = strMatch.Split(",")

            txtVBNetText = Replace(txtVBNetText, strMatch2, parts(0) & "_" & parts(1) & _
                                   "(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles " & _
                                   parts(0) & "." & parts(1), RegexOptions.IgnoreCase)

            strMatch = String.Empty
        Next

        'Handles DataGridViewCellCancelEventArgs fix
        For Each m In Regex.Matches(txtVBNetText, patternDataGridViewCellCancelEventArgs, RegexOptions.IgnoreCase Or RegexOptions.Multiline)
            strMatch = m.Value
            strMatch2 = strMatch
            strMatch = strMatch.Replace("(", " ")
            strMatch = strMatch.Replace("_", " ")
            strMatch = strMatch.Replace(" ", ",")

            parts = strMatch.Split(",")

            txtVBNetText = Replace(txtVBNetText, strMatch2, parts(0) & "_" & parts(1) & _
                                   "(sender As Object, e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles " & _
                                   parts(0) & "." & parts(1), RegexOptions.IgnoreCase)

            strMatch = String.Empty
        Next

        'Handles QuestionEventArgs fix
        For Each m In Regex.Matches(txtVBNetText, patternQuestionEventArgs, RegexOptions.IgnoreCase Or RegexOptions.Multiline)
            strMatch = m.Value
            strMatch2 = strMatch
            strMatch = strMatch.Replace("(", " ")
            strMatch = strMatch.Replace("_", " ")
            strMatch = strMatch.Replace(" ", ",")

            parts = strMatch.Split(",")

            txtVBNetText = Replace(txtVBNetText, strMatch2, parts(0) & "_" & parts(1) & _
                                   "(sender As Object, e As System.Windows.Forms.QuestionEventArgs) Handles " & _
                                   parts(0) & "." & parts(1), RegexOptions.IgnoreCase)

            strMatch = String.Empty
        Next

        'Handles DataGridViewAutoSizeColumnModeEventArgs fix
        For Each m In Regex.Matches(txtVBNetText, patternDataGridViewAutoSizeColumnModeEventArgs, RegexOptions.IgnoreCase Or RegexOptions.Multiline)
            strMatch = m.Value
            strMatch2 = strMatch
            strMatch = strMatch.Replace("(", " ")
            strMatch = strMatch.Replace("_", " ")
            strMatch = strMatch.Replace(" ", ",")

            parts = strMatch.Split(",")

            txtVBNetText = Replace(txtVBNetText, strMatch2, parts(0) & "_" & parts(1) & _
                                   "(sender As Object, e As System.Windows.Forms.DataGridViewAutoSizeColumnModeEventArgs) Handles " & _
                                   parts(0) & "." & parts(1), RegexOptions.IgnoreCase)

            strMatch = String.Empty
        Next

        'Handles RenamedEventArgs fix
        For Each m In Regex.Matches(txtVBNetText, patternRenamedEventArgs, RegexOptions.IgnoreCase Or RegexOptions.Multiline)
            strMatch = m.Value
            strMatch2 = strMatch
            strMatch = strMatch.Replace("(", " ")
            strMatch = strMatch.Replace("_", " ")
            strMatch = strMatch.Replace(" ", ",")

            parts = strMatch.Split(",")

            txtVBNetText = Replace(txtVBNetText, strMatch2, parts(0) & "_" & parts(1) & _
                                   "(sender As Object, e As System.IO.RenamedEventArgs) Handles " & _
                                   parts(0) & "." & parts(1), RegexOptions.IgnoreCase)

            strMatch = String.Empty
        Next

        'Handles ErrorEventArgs fix
        For Each m In Regex.Matches(txtVBNetText, patternErrorEventArgs, RegexOptions.IgnoreCase Or RegexOptions.Multiline)
            strMatch = m.Value
            strMatch2 = strMatch
            strMatch = strMatch.Replace("(", " ")
            strMatch = strMatch.Replace("_", " ")
            strMatch = strMatch.Replace(" ", ",")

            parts = strMatch.Split(",")

            txtVBNetText = Replace(txtVBNetText, strMatch2, parts(0) & "_" & parts(1) & _
                                   "(sender As Object, e As System.IO.ErrorEventArgs) Handles " & _
                                   parts(0) & "." & parts(1), RegexOptions.IgnoreCase)

            strMatch = String.Empty
        Next

        'Handles FileSystemEventArgs fix
        For Each m In Regex.Matches(txtVBNetText, patternFileSystemEventArgs, RegexOptions.IgnoreCase Or RegexOptions.Multiline)
            strMatch = m.Value
            strMatch2 = strMatch
            strMatch = strMatch.Replace("(", " ")
            strMatch = strMatch.Replace("_", " ")
            strMatch = strMatch.Replace(" ", ",")

            parts = strMatch.Split(",")

            txtVBNetText = Replace(txtVBNetText, strMatch2, parts(0) & "_" & parts(1) & _
                                   "(sender As Object, e As System.IO.FileSystemEventArgs) Handles " & _
                                   parts(0) & "." & parts(1), RegexOptions.IgnoreCase)

            strMatch = String.Empty
        Next

        'Handles EntryWrittenEventArgs fix
        For Each m In Regex.Matches(txtVBNetText, patternEntryWrittenEventArgs, RegexOptions.IgnoreCase Or RegexOptions.Multiline)
            strMatch = m.Value
            strMatch2 = strMatch
            strMatch = strMatch.Replace("(", " ")
            strMatch = strMatch.Replace("_", " ")
            strMatch = strMatch.Replace(" ", ",")

            parts = strMatch.Split(",")

            txtVBNetText = Replace(txtVBNetText, strMatch2, parts(0) & "_" & parts(1) & _
                                   "(sender As Object, e As System.Windows.Forms.EntryWrittenEventArgs) Handles " & _
                                   parts(0) & "." & parts(1), RegexOptions.IgnoreCase)

            strMatch = String.Empty
        Next

        'Handles ListViewVirtualItemsSelectionRangeChangedEventArgs fix
        For Each m In Regex.Matches(txtVBNetText, patternListViewVirtualItemsSelectionRangeChangedEventArgs, RegexOptions.IgnoreCase Or RegexOptions.Multiline)
            strMatch = m.Value
            strMatch2 = strMatch
            strMatch = strMatch.Replace("(", " ")
            strMatch = strMatch.Replace("_", " ")
            strMatch = strMatch.Replace(" ", ",")

            parts = strMatch.Split(",")

            txtVBNetText = Replace(txtVBNetText, strMatch2, parts(0) & "_" & parts(1) & _
                                   "(sender As Object, e As System.Windows.Forms.ListViewVirtualItemsSelectionRangeChangedEventArgs) Handles " & _
                                   parts(0) & "." & parts(1), RegexOptions.IgnoreCase)

            strMatch = String.Empty
        Next

        'Handles SearchForVirtualItemEventArgs fix
        For Each m In Regex.Matches(txtVBNetText, patternSearchForVirtualItemEventArgs, RegexOptions.IgnoreCase Or RegexOptions.Multiline)
            strMatch = m.Value
            strMatch2 = strMatch
            strMatch = strMatch.Replace("(", " ")
            strMatch = strMatch.Replace("_", " ")
            strMatch = strMatch.Replace(" ", ",")

            parts = strMatch.Split(",")

            txtVBNetText = Replace(txtVBNetText, strMatch2, parts(0) & "_" & parts(1) & _
                                   "(sender As Object, e As System.Windows.Forms.SearchForVirtualItemEventArgs) Handles " & _
                                   parts(0) & "." & parts(1), RegexOptions.IgnoreCase)

            strMatch = String.Empty
        Next

        'Handles RetrieveVirtualItemEventArgs fix
        For Each m In Regex.Matches(txtVBNetText, patternRetrieveVirtualItemEventArgs, RegexOptions.IgnoreCase Or RegexOptions.Multiline)
            strMatch = m.Value
            strMatch2 = strMatch
            strMatch = strMatch.Replace("(", " ")
            strMatch = strMatch.Replace("_", " ")
            strMatch = strMatch.Replace(" ", ",")

            parts = strMatch.Split(",")

            txtVBNetText = Replace(txtVBNetText, strMatch2, parts(0) & "_" & parts(1) & _
                                   "(sender As Object, e As System.Windows.Forms.RetrieveVirtualItemEventArgs) Handles " & _
                                   parts(0) & "." & parts(1), RegexOptions.IgnoreCase)

            strMatch = String.Empty
        Next

        'Handles ListViewItemSelectionChangedEventArgs fix
        For Each m In Regex.Matches(txtVBNetText, patternListViewItemSelectionChangedEventArgs, RegexOptions.IgnoreCase Or RegexOptions.Multiline)
            strMatch = m.Value
            strMatch2 = strMatch
            strMatch = strMatch.Replace("(", " ")
            strMatch = strMatch.Replace("_", " ")
            strMatch = strMatch.Replace(" ", ",")

            parts = strMatch.Split(",")

            txtVBNetText = Replace(txtVBNetText, strMatch2, parts(0) & "_" & parts(1) & _
                                   "(sender As Object, e As System.Windows.Forms.ListViewItemSelectionChangedEventArgs) Handles " & _
                                   parts(0) & "." & parts(1), RegexOptions.IgnoreCase)

            strMatch = String.Empty
        Next

        'Handles ListViewItemMouseHoverEventArgs fix
        For Each m In Regex.Matches(txtVBNetText, patternListViewItemMouseHoverEventArgs, RegexOptions.IgnoreCase Or RegexOptions.Multiline)
            strMatch = m.Value
            strMatch2 = strMatch
            strMatch = strMatch.Replace("(", " ")
            strMatch = strMatch.Replace("_", " ")
            strMatch = strMatch.Replace(" ", ",")

            parts = strMatch.Split(",")

            txtVBNetText = Replace(txtVBNetText, strMatch2, parts(0) & "_" & parts(1) & _
                                   "(sender As Object, e As System.Windows.Forms.ListViewItemMouseHoverEventArgs) Handles " & _
                                   parts(0) & "." & parts(1), RegexOptions.IgnoreCase)

            strMatch = String.Empty
        Next

        'Handles ItemDragEventArgs fix
        For Each m In Regex.Matches(txtVBNetText, patternItemDragEventArgs, RegexOptions.IgnoreCase Or RegexOptions.Multiline)
            strMatch = m.Value
            strMatch2 = strMatch
            strMatch = strMatch.Replace("(", " ")
            strMatch = strMatch.Replace("_", " ")
            strMatch = strMatch.Replace(" ", ",")

            parts = strMatch.Split(",")

            txtVBNetText = Replace(txtVBNetText, strMatch2, parts(0) & "_" & parts(1) & _
                                   "(sender As Object, e As System.Windows.Forms.ItemDragEventArgs) Handles " & _
                                   parts(0) & "." & parts(1), RegexOptions.IgnoreCase)

            strMatch = String.Empty
        Next

        'Handles ItemCheckEventArgs fix
        For Each m In Regex.Matches(txtVBNetText, patternItemCheckEventArgs, RegexOptions.IgnoreCase Or RegexOptions.Multiline)
            strMatch = m.Value
            strMatch2 = strMatch
            strMatch = strMatch.Replace("(", " ")
            strMatch = strMatch.Replace("_", " ")
            strMatch = strMatch.Replace(" ", ",")

            parts = strMatch.Split(",")

            txtVBNetText = Replace(txtVBNetText, strMatch2, parts(0) & "_" & parts(1) & _
                                   "(sender As Object, e As System.Windows.Forms.ItemCheckEventArgs) Handles " & _
                                   parts(0) & "." & parts(1), RegexOptions.IgnoreCase)

            strMatch = String.Empty
        Next

        'Handles DrawListViewItemEventArgs fix
        For Each m In Regex.Matches(txtVBNetText, patternDrawListViewItemEventArgs, RegexOptions.IgnoreCase Or RegexOptions.Multiline)
            strMatch = m.Value
            strMatch2 = strMatch
            strMatch = strMatch.Replace("(", " ")
            strMatch = strMatch.Replace("_", " ")
            strMatch = strMatch.Replace(" ", ",")

            parts = strMatch.Split(",")

            txtVBNetText = Replace(txtVBNetText, strMatch2, parts(0) & "_" & parts(1) & _
                                   "(sender As Object, e As System.Windows.Forms.DrawListViewItemEventArgs) Handles " & _
                                   parts(0) & "." & parts(1), RegexOptions.IgnoreCase)

            strMatch = String.Empty
        Next

        'Handles DrawListViewSubItemEventArgs fix
        For Each m In Regex.Matches(txtVBNetText, patternDrawListViewSubItemEventArgs, RegexOptions.IgnoreCase Or RegexOptions.Multiline)
            strMatch = m.Value
            strMatch2 = strMatch
            strMatch = strMatch.Replace("(", " ")
            strMatch = strMatch.Replace("_", " ")
            strMatch = strMatch.Replace(" ", ",")

            parts = strMatch.Split(",")

            txtVBNetText = Replace(txtVBNetText, strMatch2, parts(0) & "_" & parts(1) & _
                                   "(sender As Object, e As System.Windows.Forms.DrawListViewSubItemEventArgs) Handles " & _
                                   parts(0) & "." & parts(1), RegexOptions.IgnoreCase)

            strMatch = String.Empty
        Next

        'Handles DrawListViewColumnHeaderEventArgs fix
        For Each m In Regex.Matches(txtVBNetText, patternDrawListViewColumnHeaderEventArgs, RegexOptions.IgnoreCase Or RegexOptions.Multiline)
            strMatch = m.Value
            strMatch2 = strMatch
            strMatch = strMatch.Replace("(", " ")
            strMatch = strMatch.Replace("_", " ")
            strMatch = strMatch.Replace(" ", ",")

            parts = strMatch.Split(",")

            txtVBNetText = Replace(txtVBNetText, strMatch2, parts(0) & "_" & parts(1) & _
                                   "(sender As Object, e As System.Windows.Forms.DrawListViewColumnHeaderEventArgs) Handles " & _
                                   parts(0) & "." & parts(1), RegexOptions.IgnoreCase)

            strMatch = String.Empty
        Next

        'Handles ColumnWidthChangingEventArgs fix
        For Each m In Regex.Matches(txtVBNetText, patternColumnWidthChangingEventArgs, RegexOptions.IgnoreCase Or RegexOptions.Multiline)
            strMatch = m.Value
            strMatch2 = strMatch
            strMatch = strMatch.Replace("(", " ")
            strMatch = strMatch.Replace("_", " ")
            strMatch = strMatch.Replace(" ", ",")

            parts = strMatch.Split(",")

            txtVBNetText = Replace(txtVBNetText, strMatch2, parts(0) & "_" & parts(1) & _
                                   "(sender As Object, e As System.Windows.Forms.ColumnWidthChangingEventArgs) Handles " & _
                                   parts(0) & "." & parts(1), RegexOptions.IgnoreCase)

            strMatch = String.Empty
        Next

        'Handles ColumnWidthChangedEventArgs fix
        For Each m In Regex.Matches(txtVBNetText, patternColumnWidthChangedEventArgs, RegexOptions.IgnoreCase Or RegexOptions.Multiline)
            strMatch = m.Value
            strMatch2 = strMatch
            strMatch = strMatch.Replace("(", " ")
            strMatch = strMatch.Replace("_", " ")
            strMatch = strMatch.Replace(" ", ",")

            parts = strMatch.Split(",")

            txtVBNetText = Replace(txtVBNetText, strMatch2, parts(0) & "_" & parts(1) & _
                                   "(sender As Object, e As System.Windows.Forms.ColumnWidthChangedEventArgs) Handles " & _
                                   parts(0) & "." & parts(1), RegexOptions.IgnoreCase)

            strMatch = String.Empty
        Next

        'Handles ColumnReorderedEventArgs fix
        For Each m In Regex.Matches(txtVBNetText, patternColumnReorderedEventArgs, RegexOptions.IgnoreCase Or RegexOptions.Multiline)
            strMatch = m.Value
            strMatch2 = strMatch
            strMatch = strMatch.Replace("(", " ")
            strMatch = strMatch.Replace("_", " ")
            strMatch = strMatch.Replace(" ", ",")

            parts = strMatch.Split(",")

            txtVBNetText = Replace(txtVBNetText, strMatch2, parts(0) & "_" & parts(1) & _
                                   "(sender As Object, e As System.Windows.Forms.ColumnReorderedEventArgs) Handles " & _
                                   parts(0) & "." & parts(1), RegexOptions.IgnoreCase)

            strMatch = String.Empty
        Next

        'Handles ColumnClickEventArgs fix
        For Each m In Regex.Matches(txtVBNetText, patternColumnClickEventArgs, RegexOptions.IgnoreCase Or RegexOptions.Multiline)
            strMatch = m.Value
            strMatch2 = strMatch
            strMatch = strMatch.Replace("(", " ")
            strMatch = strMatch.Replace("_", " ")
            strMatch = strMatch.Replace(" ", ",")

            parts = strMatch.Split(",")

            txtVBNetText = Replace(txtVBNetText, strMatch2, parts(0) & "_" & parts(1) & _
                                   "(sender As Object, e As System.Windows.Forms.ColumnClickEventArgs) Handles " & _
                                   parts(0) & "." & parts(1), RegexOptions.IgnoreCase)

            strMatch = String.Empty
        Next

        'Handles CacheVirtualItemsEventArgs fix
        For Each m In Regex.Matches(txtVBNetText, patternCacheVirtualItemsEventArgs, RegexOptions.IgnoreCase Or RegexOptions.Multiline)
            strMatch = m.Value
            strMatch2 = strMatch
            strMatch = strMatch.Replace("(", " ")
            strMatch = strMatch.Replace("_", " ")
            strMatch = strMatch.Replace(" ", ",")

            parts = strMatch.Split(",")

            txtVBNetText = Replace(txtVBNetText, strMatch2, parts(0) & "_" & parts(1) & _
                                   "(sender As Object, e As System.Windows.Forms.CacheVirtualItemsEventArgs) Handles " & _
                                   parts(0) & "." & parts(1), RegexOptions.IgnoreCase)

            strMatch = String.Empty
        Next

        'Handles LabelEditEventArgs fix
        For Each m In Regex.Matches(txtVBNetText, patternLabelEditEventArgs, RegexOptions.IgnoreCase Or RegexOptions.Multiline)
            strMatch = m.Value
            strMatch2 = strMatch
            strMatch = strMatch.Replace("(", " ")
            strMatch = strMatch.Replace("_", " ")
            strMatch = strMatch.Replace(" ", ",")

            parts = strMatch.Split(",")

            txtVBNetText = Replace(txtVBNetText, strMatch2, parts(0) & "_" & parts(1) & _
                                   "(sender As Object, e As System.Windows.Forms.LabelEditEventArgs) Handles " & _
                                   parts(0) & "." & parts(1), RegexOptions.IgnoreCase)

            strMatch = String.Empty
        Next

        'Handles FormClosingEventArgs fix
        For Each m In Regex.Matches(txtVBNetText, patternFormClosingEventArgs, RegexOptions.IgnoreCase Or RegexOptions.Multiline)
            strMatch = m.Value
            strMatch2 = strMatch
            strMatch = strMatch.Replace("(", " ")
            strMatch = strMatch.Replace("_", " ")
            strMatch = strMatch.Replace(" ", ",")

            parts = strMatch.Split(",")

            txtVBNetText = Replace(txtVBNetText, strMatch2, parts(0) & "_" & parts(1) & _
                                   "(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles " & _
                                   parts(0) & "." & parts(1), RegexOptions.IgnoreCase)

            strMatch = String.Empty
        Next

        'Handles FormClosedEventArgs fix
        For Each m In Regex.Matches(txtVBNetText, patternFormClosedEventArgs, RegexOptions.IgnoreCase Or RegexOptions.Multiline)
            strMatch = m.Value
            strMatch2 = strMatch
            strMatch = strMatch.Replace("(", " ")
            strMatch = strMatch.Replace("_", " ")
            strMatch = strMatch.Replace(" ", ",")

            parts = strMatch.Split(",")

            txtVBNetText = Replace(txtVBNetText, strMatch2, parts(0) & "_" & parts(1) & _
                                   "(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles " & _
                                   parts(0) & "." & parts(1), RegexOptions.IgnoreCase)

            strMatch = String.Empty
        Next

        'Handles ComponentModelCancelEventArgs fix
        For Each m In Regex.Matches(txtVBNetText, patternComponentModelCancelEventArgs, RegexOptions.IgnoreCase Or RegexOptions.Multiline)
            strMatch = m.Value
            strMatch2 = strMatch
            strMatch = strMatch.Replace("(", " ")
            strMatch = strMatch.Replace("_", " ")
            strMatch = strMatch.Replace(" ", ",")

            parts = strMatch.Split(",")

            txtVBNetText = Replace(txtVBNetText, strMatch2, parts(0) & "_" & parts(1) & _
                                   "(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles " & _
                                   parts(0) & "." & parts(1), RegexOptions.IgnoreCase)

            strMatch = String.Empty
        Next

        'Handles InputLanguageChangedEventArgs fix
        For Each m In Regex.Matches(txtVBNetText, patternInputLanguageChangedEventArgs, RegexOptions.IgnoreCase Or RegexOptions.Multiline)
            strMatch = m.Value
            strMatch2 = strMatch
            strMatch = strMatch.Replace("(", " ")
            strMatch = strMatch.Replace("_", " ")
            strMatch = strMatch.Replace(" ", ",")

            parts = strMatch.Split(",")

            txtVBNetText = Replace(txtVBNetText, strMatch2, parts(0) & "_" & parts(1) & _
                                   "(sender As Object, e As System.Windows.Forms.InputLanguageChangedEventArgs) Handles " & _
                                   parts(0) & "." & parts(1), RegexOptions.IgnoreCase)

            strMatch = String.Empty
        Next

        'Handles InputLanguageChangingEventArgs fix
        For Each m In Regex.Matches(txtVBNetText, patternInputLanguageChangingEventArgs, RegexOptions.IgnoreCase Or RegexOptions.Multiline)
            strMatch = m.Value
            strMatch2 = strMatch
            strMatch = strMatch.Replace("(", " ")
            strMatch = strMatch.Replace("_", " ")
            strMatch = strMatch.Replace(" ", ",")

            parts = strMatch.Split(",")

            txtVBNetText = Replace(txtVBNetText, strMatch2, parts(0) & "_" & parts(1) & _
                                   "(sender As Object, e As System.Windows.Forms.InputLanguageChangingEventArgs) Handles " & _
                                   parts(0) & "." & parts(1), RegexOptions.IgnoreCase)

            strMatch = String.Empty
        Next

        'Handles ScrollEventArgs fix
        For Each m In Regex.Matches(txtVBNetText, patternScrollEventArgs, RegexOptions.IgnoreCase Or RegexOptions.Multiline)
            strMatch = m.Value
            strMatch2 = strMatch
            strMatch = strMatch.Replace("(", " ")
            strMatch = strMatch.Replace("_", " ")
            strMatch = strMatch.Replace(" ", ",")

            parts = strMatch.Split(",")

            txtVBNetText = Replace(txtVBNetText, strMatch2, parts(0) & "_" & parts(1) & _
                                   "(sender As Object, e As System.Windows.Forms.ScrollEventArgs) Handles " & _
                                   parts(0) & "." & parts(1), RegexOptions.IgnoreCase)

            strMatch = String.Empty
        Next

        'Handles MeasureItemEventArgs fix
        For Each m In Regex.Matches(txtVBNetText, patternMeasureItemEventArgs, RegexOptions.IgnoreCase Or RegexOptions.Multiline)
            strMatch = m.Value
            strMatch2 = strMatch
            strMatch = strMatch.Replace("(", " ")
            strMatch = strMatch.Replace("_", " ")
            strMatch = strMatch.Replace(" ", ",")

            parts = strMatch.Split(",")

            txtVBNetText = Replace(txtVBNetText, strMatch2, parts(0) & "_" & parts(1) & _
                                   "(sender As Object, e As System.Windows.Forms.MeasureItemEventArgs) Handles " & _
                                   parts(0) & "." & parts(1), RegexOptions.IgnoreCase)

            strMatch = String.Empty
        Next

        'Handles ListControlConvertEventArgs fix
        For Each m In Regex.Matches(txtVBNetText, patternListControlConvertEventArgs, RegexOptions.IgnoreCase Or RegexOptions.Multiline)
            strMatch = m.Value
            strMatch2 = strMatch
            strMatch = strMatch.Replace("(", " ")
            strMatch = strMatch.Replace("_", " ")
            strMatch = strMatch.Replace(" ", ",")

            parts = strMatch.Split(",")

            txtVBNetText = Replace(txtVBNetText, strMatch2, parts(0) & "_" & parts(1) & _
                                   "(sender As Object, e As System.Windows.Forms.ListControlConvertEventArgs) Handles " & _
                                   parts(0) & "." & parts(1), RegexOptions.IgnoreCase)

            strMatch = String.Empty
        Next

        'Handles DrawItemEventArgs fix
        For Each m In Regex.Matches(txtVBNetText, patternDrawItemEventArgs, RegexOptions.IgnoreCase Or RegexOptions.Multiline)
            strMatch = m.Value
            strMatch2 = strMatch
            strMatch = strMatch.Replace("(", " ")
            strMatch = strMatch.Replace("_", " ")
            strMatch = strMatch.Replace(" ", ",")

            parts = strMatch.Split(",")

            txtVBNetText = Replace(txtVBNetText, strMatch2, parts(0) & "_" & parts(1) & _
                                   "(sender As Object, e As System.Windows.Forms.DrawItemEventArgs) Handles " & _
                                   parts(0) & "." & parts(1), RegexOptions.IgnoreCase)

            strMatch = String.Empty
        Next

        'Handles ControlEventArgs fix
        For Each m In Regex.Matches(txtVBNetText, patternControlAddedRemoved, RegexOptions.IgnoreCase Or RegexOptions.Multiline)
            strMatch = m.Value
            strMatch2 = strMatch
            strMatch = strMatch.Replace("(", " ")
            strMatch = strMatch.Replace("_", " ")
            strMatch = strMatch.Replace(" ", ",")

            parts = strMatch.Split(",")

            txtVBNetText = Replace(txtVBNetText, strMatch2, parts(0) & "_" & parts(1) & _
                                   "(sender As Object, e As System.Windows.Forms.ControlEventArgs) Handles " & _
                                   parts(0) & "." & parts(1), RegexOptions.IgnoreCase)

            strMatch = String.Empty
        Next

        'Handles PrintEventArgs fix
        For Each m In Regex.Matches(txtVBNetText, patternPrintEventArgs, RegexOptions.IgnoreCase Or RegexOptions.Multiline)
            strMatch = m.Value
            strMatch2 = strMatch
            strMatch = strMatch.Replace("(", " ")
            strMatch = strMatch.Replace("_", " ")
            strMatch = strMatch.Replace(" ", ",")

            parts = strMatch.Split(",")

            txtVBNetText = Replace(txtVBNetText, strMatch2, parts(0) & "_" & parts(1) & _
                                   "(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles " & _
                                   parts(0) & "." & parts(1), RegexOptions.IgnoreCase)

            strMatch = String.Empty
        Next

        'Handles PrintPageEventArgs fix
        For Each m In Regex.Matches(txtVBNetText, patternPrintPageEventArgs, RegexOptions.IgnoreCase Or RegexOptions.Multiline)
            strMatch = m.Value
            strMatch2 = strMatch
            strMatch = strMatch.Replace("(", " ")
            strMatch = strMatch.Replace("_", " ")
            strMatch = strMatch.Replace(" ", ",")

            parts = strMatch.Split(",")

            txtVBNetText = Replace(txtVBNetText, strMatch2, parts(0) & "_" & parts(1) & _
                                   "(sender As Object, e As System.Drawing.Printing.PrintPageEventArgs) Handles " & _
                                   parts(0) & "." & parts(1), RegexOptions.IgnoreCase)

            strMatch = String.Empty
        Next

        'Handles QueryPageSettingsEventArgs fix
        For Each m In Regex.Matches(txtVBNetText, patternQueryPageSettingsEventArgs, RegexOptions.IgnoreCase Or RegexOptions.Multiline)
            strMatch = m.Value
            strMatch2 = strMatch
            strMatch = strMatch.Replace("(", " ")
            strMatch = strMatch.Replace("_", " ")
            strMatch = strMatch.Replace(" ", ",")

            parts = strMatch.Split(",")

            txtVBNetText = Replace(txtVBNetText, strMatch2, parts(0) & "_" & parts(1) & _
                                   "(sender As Object, e As System.Drawing.Printing.QueryPageSettingsEventArgs) Handles " & _
                                   parts(0) & "." & parts(1), RegexOptions.IgnoreCase)

            strMatch = String.Empty
        Next

        'Handles UICuesEventArgs fix
        For Each m In Regex.Matches(txtVBNetText, patternChangeUICues, RegexOptions.IgnoreCase Or RegexOptions.Multiline)
            strMatch = m.Value
            strMatch2 = strMatch
            strMatch = strMatch.Replace("(", " ")
            strMatch = strMatch.Replace("_", " ")
            strMatch = strMatch.Replace(" ", ",")

            parts = strMatch.Split(",")

            txtVBNetText = Replace(txtVBNetText, strMatch2, parts(0) & "_" & parts(1) & _
                                   "(sender As Object, e As System.Windows.Forms.UICuesEventArgs) Handles " & _
                                   parts(0) & "." & parts(1), RegexOptions.IgnoreCase)

            strMatch = String.Empty
        Next

        'Handles GiveFeedbackEventArgs fix
        For Each m In Regex.Matches(txtVBNetText, patternGiveFeedback, RegexOptions.IgnoreCase Or RegexOptions.Multiline)
            strMatch = m.Value
            strMatch2 = strMatch
            strMatch = strMatch.Replace("(", " ")
            strMatch = strMatch.Replace("_", " ")
            strMatch = strMatch.Replace(" ", ",")

            parts = strMatch.Split(",")

            txtVBNetText = Replace(txtVBNetText, strMatch2, parts(0) & "_" & parts(1) & _
                                   "(sender As Object, e As System.Windows.Forms.GiveFeedbackEventArgs) Handles " & _
                                   parts(0) & "." & parts(1), RegexOptions.IgnoreCase)

            strMatch = String.Empty
        Next

        'Handles HelpEventArgs fix
        For Each m In Regex.Matches(txtVBNetText, patternHelpRequested, RegexOptions.IgnoreCase Or RegexOptions.Multiline)
            strMatch = m.Value
            strMatch2 = strMatch
            strMatch = strMatch.Replace("(", " ")
            strMatch = strMatch.Replace("_", " ")
            strMatch = strMatch.Replace(" ", ",")

            parts = strMatch.Split(",")

            txtVBNetText = Replace(txtVBNetText, strMatch2, parts(0) & "_" & parts(1) & _
                                   "(sender As Object, hlpevent As System.Windows.Forms.HelpEventArgs) Handles " & _
                                   parts(0) & "." & parts(1), RegexOptions.IgnoreCase)

            strMatch = String.Empty
        Next

        'Handles InvalidateEventArgs fix
        For Each m In Regex.Matches(txtVBNetText, patternInvalidated, RegexOptions.IgnoreCase Or RegexOptions.Multiline)
            strMatch = m.Value
            strMatch2 = strMatch
            strMatch = strMatch.Replace("(", " ")
            strMatch = strMatch.Replace("_", " ")
            strMatch = strMatch.Replace(" ", ",")

            parts = strMatch.Split(",")

            txtVBNetText = Replace(txtVBNetText, strMatch2, parts(0) & "_" & parts(1) & _
                                   "(sender As Object, e As System.Windows.Forms.InvalidateEventArgs) Handles " & _
                                   parts(0) & "." & parts(1), RegexOptions.IgnoreCase)

            strMatch = String.Empty
        Next

        'Handles CancelEventArgs fix
        For Each m In Regex.Matches(txtVBNetText, patternCancelEventArgs, RegexOptions.IgnoreCase Or RegexOptions.Multiline)
            strMatch = m.Value
            strMatch2 = strMatch
            strMatch = strMatch.Replace("(", " ")
            strMatch = strMatch.Replace("_", " ")
            strMatch = strMatch.Replace(" ", ",")

            parts = strMatch.Split(",")

            txtVBNetText = Replace(txtVBNetText, strMatch2, parts(0) & "_" & parts(1) & _
                                   "(sender As Object, e As System.Windows.Forms.CancelEventArgs) Handles " & _
                                   parts(0) & "." & parts(1), RegexOptions.IgnoreCase)

            strMatch = String.Empty
        Next

        'Handles Form.CancelEventArgs fix
        For Each m In Regex.Matches(txtVBNetText, patternFormClosingEventArgs, RegexOptions.IgnoreCase Or RegexOptions.Multiline)
            strMatch = m.Value
            strMatch2 = strMatch
            strMatch = strMatch.Replace("(", " ")
            strMatch = strMatch.Replace("_", " ")
            strMatch = strMatch.Replace(" ", ",")

            parts = strMatch.Split(",")

            txtVBNetText = Replace(txtVBNetText, strMatch2, parts(0) & "_" & parts(1) & _
                                   "(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles " & _
                                   "Me." & parts(1), RegexOptions.IgnoreCase)

            strMatch = String.Empty
        Next

        'Handles QueryContinueDragEventArgs fix
        For Each m In Regex.Matches(txtVBNetText, patternQueryContinueDragEventArgs, RegexOptions.IgnoreCase Or RegexOptions.Multiline)
            strMatch = m.Value
            strMatch2 = strMatch
            strMatch = strMatch.Replace("(", " ")
            strMatch = strMatch.Replace("_", " ")
            strMatch = strMatch.Replace(" ", ",")

            parts = strMatch.Split(",")

            txtVBNetText = Replace(txtVBNetText, strMatch2, parts(0) & "_" & parts(1) & _
                                   "(sender As Object, e As System.Windows.Forms.QueryContinueDragEventArgs) Handles " & _
                                   parts(0) & "." & parts(1), RegexOptions.IgnoreCase)

            strMatch = String.Empty
        Next

        'Handles QueryAccessibilityHelpEventArgs fix
        For Each m In Regex.Matches(txtVBNetText, patternQueryAccessibilityHelpEventArgs, RegexOptions.IgnoreCase Or RegexOptions.Multiline)
            strMatch = m.Value
            strMatch2 = strMatch
            strMatch = strMatch.Replace("(", " ")
            strMatch = strMatch.Replace("_", " ")
            strMatch = strMatch.Replace(" ", ",")

            parts = strMatch.Split(",")

            txtVBNetText = Replace(txtVBNetText, strMatch2, parts(0) & "_" & parts(1) & _
                                   "(sender As Object, e As System.Windows.Forms.QueryAccessibilityHelpEventArgs) Handles " & _
                                   parts(0) & "." & parts(1), RegexOptions.IgnoreCase)

            strMatch = String.Empty
        Next

        'Handles LayoutEventArgs fix
        For Each m In Regex.Matches(txtVBNetText, patternLayoutEventArgs, RegexOptions.IgnoreCase Or RegexOptions.Multiline)
            strMatch = m.Value
            strMatch2 = strMatch
            strMatch = strMatch.Replace("(", " ")
            strMatch = strMatch.Replace("_", " ")
            strMatch = strMatch.Replace(" ", ",")

            parts = strMatch.Split(",")

            txtVBNetText = Replace(txtVBNetText, strMatch2, parts(0) & "_" & parts(1) & _
                                   "(sender As Object, e As System.Windows.Forms.LayoutEventArgs) Handles " & _
                                   parts(0) & "." & parts(1), RegexOptions.IgnoreCase)

            strMatch = String.Empty
        Next

        'Handles PaintEventArgs fix
        For Each m In Regex.Matches(txtVBNetText, patternPaintEventArgs, RegexOptions.IgnoreCase)
            strMatch = m.Value
            strMatch2 = strMatch
            strMatch = strMatch.Replace("(", " ")
            strMatch = strMatch.Replace("_", " ")
            strMatch = strMatch.Replace(" ", ",")

            parts = strMatch.Split(",")

            txtVBNetText = Replace(txtVBNetText, strMatch2, parts(0) & "_" & parts(1) & _
                                   "(sender As Object, e As System.Windows.Forms.PaintEventArgs) Handles " & _
                                   "Me." & parts(1), RegexOptions.IgnoreCase)

            strMatch = String.Empty
        Next

        'Handles PreviewKeyDownEventArgs fix
        For Each m In Regex.Matches(txtVBNetText, patternPreviewKeyDownEventArgs, RegexOptions.IgnoreCase Or RegexOptions.Multiline)
            strMatch = m.Value
            strMatch2 = strMatch
            strMatch = strMatch.Replace("(", " ")
            strMatch = strMatch.Replace("_", " ")
            strMatch = strMatch.Replace(" ", ",")

            parts = strMatch.Split(",")

            txtVBNetText = Replace(txtVBNetText, strMatch2, parts(0) & "_" & parts(1) & _
                                   "(sender As Object, e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles " & _
                                   parts(0) & "." & parts(1), RegexOptions.IgnoreCase)

            strMatch = String.Empty
        Next

        'Handles ?.DoWork, RunWorkerCompleted fix
        For Each m In Regex.Matches(txtVBNetText, patternBackgroundWorker, RegexOptions.IgnoreCase Or RegexOptions.Multiline)
            strMatch = m.Value
            strMatch2 = strMatch
            strMatch = strMatch.Replace("(", " ")
            strMatch = strMatch.Replace("_", " ")
            strMatch = strMatch.Replace(" ", ",")

            parts = strMatch.Split(",")

            txtVBNetText = Replace(txtVBNetText, strMatch2, parts(0) & "_" & parts(1) & _
                                   "(sender As Object, e As " & parts(8) & " Handles " & _
                                   parts(0) & "." & parts(1), RegexOptions.IgnoreCase)

            strMatch = String.Empty
        Next

        'Handles ?.MouseUp, MouseDown, MouseMove fix
        For Each m In Regex.Matches(txtVBNetText, patternMouseEventArgs, RegexOptions.IgnoreCase Or RegexOptions.Multiline)
            strMatch = m.Value
            strMatch2 = strMatch
            strMatch = strMatch.Replace("(", " ")
            strMatch = strMatch.Replace("_", " ")
            strMatch = strMatch.Replace(" ", ",")

            parts = strMatch.Split(",")

            txtVBNetText = Replace(txtVBNetText, strMatch2, parts(0) & "_" & parts(1) & _
                                   "(sender As Object, e As MouseEventArgs)" & " Handles " & _
                                   parts(0) & "." & parts(1), RegexOptions.IgnoreCase)

            strMatch = String.Empty
        Next

        'Handles ?.KeyUp, KeyDown fix
        For Each m In Regex.Matches(txtVBNetText, patternKeysUpDown, RegexOptions.IgnoreCase Or RegexOptions.Multiline)
            strMatch = m.Value
            strMatch2 = strMatch
            strMatch = strMatch.Replace("(", " ")
            strMatch = strMatch.Replace("_", " ")
            strMatch = strMatch.Replace(" ", ",")

            parts = strMatch.Split(",")

            txtVBNetText = Replace(txtVBNetText, strMatch2, parts(0) & "_" & parts(1) & _
                                   "(sender As Object, e As System.Windows.Forms.KeyEventArgs)" & " Handles " & _
                                   parts(0) & "." & parts(1), RegexOptions.IgnoreCase)

            strMatch = String.Empty
        Next

        'Handles ?.KeyPress fix
        For Each m In Regex.Matches(txtVBNetText, patternKeyPress, RegexOptions.IgnoreCase Or RegexOptions.Multiline)
            strMatch = m.Value
            strMatch2 = strMatch
            strMatch = strMatch.Replace("(", " ")
            strMatch = strMatch.Replace("_", " ")
            strMatch = strMatch.Replace(" ", ",")

            parts = strMatch.Split(",")

            txtVBNetText = Replace(txtVBNetText, strMatch2, parts(0) & "_" & parts(1) & _
                                   "(sender As Object, e As System.Windows.Forms.KeyPressEventArgs)" & " Handles " & _
                                   parts(0) & "." & parts(1), RegexOptions.IgnoreCase)

            strMatch = String.Empty
        Next

        'Handles ?.DragDrop, DragEnter fix
        For Each m In Regex.Matches(txtVBNetText, patternDragDropEnter, RegexOptions.IgnoreCase Or RegexOptions.Multiline)
            strMatch = m.Value
            strMatch2 = strMatch
            strMatch = strMatch.Replace("(", " ")
            strMatch = strMatch.Replace("_", " ")
            strMatch = strMatch.Replace(" ", ",")

            parts = strMatch.Split(",")

            txtVBNetText = Replace(txtVBNetText, strMatch2, parts(0) & "_" & parts(1) & _
                                   "(sender As Object, e As System.Windows.Forms.DragEventArgs)" & " Handles " & _
                                   parts(0) & "." & parts(1), RegexOptions.IgnoreCase)

            strMatch = String.Empty
        Next

        Return txtVBNetText
    End Function

    Public Shared Function FixVB2(ByVal txt As String) As String
        Dim m As Match
        Dim strMatch As String
        Dim txtVBNetText As String = txt

        'Comment Strings left behind due to conversion that need repairing.
        Dim cmmt1 As String = "EmptyLineVar\sAs\sString"
        Dim cmmt2 As String = "CommentVar\sAs\sString\s\=\s\""" & "(\s\/\/|\/\/)"
        Dim cmmt3 As String = "RegionVar\sAs\sString\s\=\s\""" & "(\#region|\#\sregion|\s\#\sregion)\s"
        Dim cmmt4 As String = "RegionVar\sAs\sString\s\=\s\""" & "(\#endregion|\#\sendregion|\s\#\sendregion)" & """"

        Dim patternWebBrowserProgressChangedEventArgs As String = "\b\w+_ProgressChanged\((ByVal\ssender\sAs\sObject\,\sByVal\se\sAs\sSystem\.Windows\.Forms\.WebBrowserProgressChangedEventArgs\)|sender\sAs\sObject\,\se\sAs\sSystem\.Windows\.Forms\.WebBrowserProgressChangedEventArgs\)|sender\sAs\sObject\,\se\sAs\sWebBrowserProgressChangedEventArgs)\)"

        Dim patternWebBrowserNavigatedEventArgs As String = "\b\w+_Navigating\((ByVal\ssender\sAs\sObject\,\sByVal\se\sAs\sSystem\.Windows\.Forms\.WebBrowserNavigatingEventArgs\)|sender\sAs\sObject\,\se\sAs\sSystem\.Windows\.Forms\.WebBrowserNavigatingEventArgs\)|sender\sAs\sObject\,\se\sAs\sWebBrowserNavigatingEventArgs)\)"

        Dim patternWebBrowserNavigatingEventArgs As String = "\b\w+_Navigated\((ByVal\ssender\sAs\sObject\,\sByVal\se\sAs\sSystem\.Windows\.Forms\.WebBrowserNavigatedEventArgs\)|sender\sAs\sObject\,\se\sAs\sSystem\.Windows\.Forms\.WebBrowserNavigatedEventArgs\)|sender\sAs\sObject\,\se\sAs\sWebBrowserNavigatedEventArgs)\)"

        Dim patternWebBrowserDocumentCompletedEventArgs As String = "\b\w+_DocumentCompleted\((ByVal\ssender\sAs\sObject\,\sByVal\se\sAs\sSystem\.Windows\.Forms\.WebBrowserDocumentCompletedEventArgs\)|sender\sAs\sObject\,\se\sAs\sSystem\.Windows\.Forms\.WebBrowserDocumentCompletedEventArgs\)|sender\sAs\sObject\,\se\sAs\sWebBrowserDocumentCompletedEventArgs)\)"
        '(----------------------------------------------------)
        Dim patternTreeNodeMouseHoverEventArgs As String = "\b\w+_NodeMouseHover\((ByVal\ssender\sAs\sObject\,\sByVal\se\sAs\sSystem\.Windows\.Forms\.TreeNodeMouseHoverEventArgs\)|sender\sAs\sObject\,\se\sAs\sSystem\.Windows\.Forms\.TreeNodeMouseHoverEventArgs\)|sender\sAs\sObject\,\se\sAs\sTreeNodeMouseHoverEventArgs)\)"

        Dim patternTreeNodeMouseClickEventArgs As String = "\b\w+_(NodeMouseClick|NodeMouseDoubleClick)\((ByVal\ssender\sAs\sObject\,\sByVal\se\sAs\sSystem\.Windows\.Forms\.TreeNodeMouseClickEventArgs\)|sender\sAs\sObject\,\se\sAs\sSystem\.Windows\.Forms\.TreeNodeMouseClickEventArgs\)|sender\sAs\sObject\,\se\sAs\sTreeNodeMouseClickEventArgs)\)"

        Dim patternDrawTreeNodeEventArgs As String = "\b\w+_DrawNode\((ByVal\ssender\sAs\sObject\,\sByVal\se\sAs\sSystem\.Windows\.Forms\.DrawTreeNodeEventArgs\)|sender\sAs\sObject\,\se\sAs\sSystem\.Windows\.Forms\.DrawTreeNodeEventArgs\)|sender\sAs\sObject\,\se\sAs\sDrawTreeNodeEventArgs)\)"

        Dim patternTreeViewCancelEventArgs As String = "\b\w+_(BeforeCheck|BeforeCollapse|BeforeExpand|BeforeSelect)\((ByVal\ssender\sAs\sObject\,\sByVal\se\sAs\sSystem\.Windows\.Forms\.AddingNewEventArgs\)|sender\sAs\sObject\,\se\sAs\sSystem\.Windows\.Forms\.AddingNewEventArgs\)|sender\sAs\sObject\,\se\sAs\sAddingNewEventArgs)\)"

        Dim patternNodeLabelEditEventArgs As String = "\b\w+_(AfterLabelEdit|BeforeLabelEdit)\((ByVal\ssender\sAs\sObject\,\sByVal\se\sAs\sSystem\.Windows\.Forms\.NodeLabelEditEventArgs\)|sender\sAs\sObject\,\se\sAs\sSystem\.Windows\.Forms\.NodeLabelEditEventArgs\)|sender\sAs\sObject\,\se\sAs\sNodeLabelEditEventArgs)\)"

        Dim patternTreeViewEventArgs As String = "\b\w+_(AfterCheck|AfterCollapse|AfterExpand|AfterSelect)\((ByVal\ssender\sAs\sObject\,\sByVal\se\sAs\sSystem\.Windows\.Forms\.TreeViewEventArgs\)|sender\sAs\sObject\,\se\sAs\sSystem\.Windows\.Forms\.TreeViewEventArgs\)|sender\sAs\sObject\,\se\sAs\sTreeViewEventArgs)\)"

        Dim patternPopupEventArgs As String = "\b\w+_Popup\((ByVal\ssender\sAs\sObject\,\sByVal\se\sAs\sSystem\.Windows\.Forms\.PopupEventArgs\)|sender\sAs\sObject\,\se\sAs\sSystem\.Windows\.Forms\.PopupEventArgs\)|sender\sAs\sObject\,\se\sAs\sPopupEventArgs)\)"

        Dim patternDrawToolTipEventArgs As String = "\b\w+_Draw\((ByVal\ssender\sAs\sObject\,\sByVal\se\sAs\sSystem\.Windows\.Forms\.DrawToolTipEventArgs\)|sender\sAs\sObject\,\se\sAs\sSystem\.Windows\.Forms\.DrawToolTipEventArgs\)|sender\sAs\sObject\,\se\sAs\sDrawToolTipEventArgs)\)"

        Dim patternTabControlCancelEventArgs As String = "\b\w+_(Deselecting|Selecting)\((ByVal\ssender\sAs\sObject\,\sByVal\se\sAs\sSystem\.Windows\.Forms\.TabControlCancelEventArgs\)|sender\sAs\sObject\,\se\sAs\sSystem\.Windows\.Forms\.TabControlCancelEventArgs\)|sender\sAs\sObject\,\se\sAs\sTabControlCancelEventArgs)\)"

        Dim patternTabControlEventArgs As String = "\b\w+_Deselected\((ByVal\ssender\sAs\sObject\,\sByVal\se\sAs\sSystem\.Windows\.Forms\.TabControlEventArgs\)|sender\sAs\sObject\,\se\sAs\sSystem\.Windows\.Forms\.TabControlEventArgs\)|sender\sAs\sObject\,\se\sAs\sTabControlEventArgs)\)"

        Dim patternSplitterCancelEventArgs As String = "\b\w+_SplitterMoving\((ByVal\ssender\sAs\sObject\,\sByVal\se\sAs\sSystem\.Windows\.Forms\.SplitterCancelEventArgs\)|sender\sAs\sObject\,\se\sAs\sSystem\.Windows\.Forms\.SplitterCancelEventArgs\)|sender\sAs\sObject\,\se\sAs\sSplitterCancelEventArgs)\)"

        Dim patternSplitterEventArgs As String = "\b\w+_SplitterMoved\((ByVal\ssender\sAs\sObject\,\sByVal\se\sAs\sSystem\.Windows\.Forms\.SplitterEventArgs\)|sender\sAs\sObject\,\se\sAs\sSystem\.Windows\.Forms\.SplitterEventArgs\)|sender\sAs\sObject\,\se\sAs\sSplitterEventArgs)\)"

        Dim patternSerialPinChangedEventArgs As String = "\b\w+_AddingNew\((ByVal\ssender\sAs\sObject\,\sByVal\se\sAs\sSystem\.IO\.Ports\.SerialPinChangedEventArgs\)|sender\sAs\sObject\,\se\sAs\sSystem\.IO\.Ports\.SerialPinChangedEventArgs\)|sender\sAs\sObject\,\se\sAs\sSerialPinChangedEventArgs)\)"

        Dim patternSerialErrorReceivedEventArgs As String = "\b\w+_AddingNew\((ByVal\ssender\sAs\sObject\,\sByVal\se\sAs\sSystem\.IO\.Ports\.SerialErrorReceivedEventArgs\)|sender\sAs\sObject\,\se\sAs\sSystem\.IO\.Ports\.SerialErrorReceivedEventArgs\)|sender\sAs\sObject\,\se\sAs\sSerialErrorReceivedEventArgs)\)"

        Dim patternSerialDataReceivedEventArgs As String = "\b\w+_DataReceived\((ByVal\ssender\sAs\sObject\,\sByVal\se\sAs\sSystem\.IO\.Ports\.SerialDataReceivedEventArgs\)|sender\sAs\sObject\,\se\sAs\sSystem\.IO\.Ports\.SerialDataReceivedEventArgs\)|sender\sAs\sObject\,\se\sAs\sSerialDataReceivedEventArgs)\)"

        Dim patternLinkClickedEventArgs As String = "\b\w+_LinkClicked\((ByVal\ssender\sAs\sObject\,\sByVal\se\sAs\sSystem\.Windows\.Forms\.LinkClickedEventArgs\)|sender\sAs\sObject\,\se\sAs\sSystem\.Windows\.Forms\.LinkClickedEventArgs\)|sender\sAs\sObject\,\se\sAs\sLinkClickedEventArgs)\)"

        Dim patternSelectedGridItemChangedEventArgs As String = "\b\w+_SelectedGridItemChanged\((ByVal\ssender\sAs\sObject\,\sByVal\se\sAs\sSystem\.Windows\.Forms\.SelectedGridItemChangedEventArgs\)|sender\sAs\sObject\,\se\sAs\sSystem\.Windows\.Forms\.SelectedGridItemChangedEventArgs\)|sender\sAs\sObject\,\se\sAs\sSelectedGridItemChangedEventArgs)\)"

        Dim patternPropertyValueChangedEventArgs As String = "\b\w+_PropertyValueChanged\((ByVal\ssender\sAs\sObject\,\sByVal\se\sAs\sSystem\.Windows\.Forms\.PropertyValueChangedEventArgs\)|sender\sAs\sObject\,\se\sAs\sSystem\.Windows\.Forms\.PropertyValueChangedEventArgs\)|sender\sAs\sObject\,\se\sAs\sPropertyValueChangedEventArgs)\)"

        Dim patternPropertyTabChangedEventArgs As String = "\b\w+_PropertyTabChanged\((ByVal\ssender\sAs\sObject\,\sByVal\se\sAs\sSystem\.Windows\.Forms\.PropertyTabChangedEventArgs\)|sender\sAs\sObject\,\se\sAs\sSystem\.Windows\.Forms\.PropertyTabChangedEventArgs\)|sender\sAs\sObject\,\se\sAs\sPropertyTabChangedEventArgs)\)"

        Dim patternDataReceivedEventArgs As String = "\b\w+_(ErrorDataReceived|OutputDataReceived)\((ByVal\ssender\sAs\sObject\,\sByVal\se\sAs\sSystem\.Diagnostics\.DataReceivedEventArgs\)|sender\sAs\sObject\,\se\sAs\sSystem\.Diagnostics\.DataReceivedEventArgs\)|sender\sAs\sObject\,\se\sAs\sDataReceivedEventArgs)\)"

        Dim patternProgressChangedEventArgs As String = "\b\w+_LoadProgressChanged\((ByVal\ssender\sAs\sObject\,\sByVal\se\sAs\sSystem\.ComponentModel\.ProgressChangedEventArgs\)|sender\sAs\sObject\,\se\sAs\sSystem\.ComponentModel\.ProgressChangedEventArgs\)|sender\sAs\sObject\,\se\sAs\sProgressChangedEventArgs)\)"

        Dim patternAsyncCompletedEventArgs As String = "\b\w+_LoadCompleted\((ByVal\ssender\sAs\sObject\,\sByVal\se\sAs\sSystem\.ComponentModel\.AsyncCompletedEventArgs\)|sender\sAs\sObject\,\se\sAs\sSystem\.ComponentModel\.AsyncCompletedEventArgs\)|sender\sAs\sObject\,\se\sAs\sAsyncCompletedEventArgs)\)"

        Dim patternTypeValidationEventArgs As String = "\b\w+_TypeValidationCompleted\((ByVal\ssender\sAs\sObject\,\sByVal\se\sAs\sSystem\.Windows\.Forms\.TypeValidationEventArgs\)|sender\sAs\sObject\,\se\sAs\sSystem\.Windows\.Forms\.TypeValidationEventArgs\)|sender\sAs\sObject\,\se\sAs\sTypeValidationEventArgs)\)"

        Dim patternMaskInputRejectedEventArgs As String = "\b\w+_MaskInputRejected\((ByVal\ssender\sAs\sObject\,\sByVal\se\sAs\sSystem\.Windows\.Forms\.MaskInputRejectedEventArgs\)|sender\sAs\sObject\,\se\sAs\sSystem\.Windows\.Forms\.MaskInputRejectedEventArgs\)|sender\sAs\sObject\,\se\sAs\sMaskInputRejectedEventArgs)\)"

        Dim patternLinkLabelLinkClickedEventArgs As String = "\b\w+_LinkClicked\((ByVal\ssender\sAs\sObject\,\sByVal\se\sAs\sSystem\.Windows\.Forms\.LinkLabelLinkClickedEventArgs\)|sender\sAs\sObject\,\se\sAs\sSystem\.Windows\.Forms\.LinkLabelLinkClickedEventArgs\)|sender\sAs\sObject\,\se\sAs\sLinkLabelLinkClickedEventArgs)\)"

        Dim patternToolStripItemClickedEventArgs As String = "\b\w+_ItemClicked\((ByVal\ssender\sAs\sObject\,\sByVal\se\sAs\sSystem\.Windows\.Forms\.ToolStripItemClickedEventArgs\)|sender\sAs\sObject\,\se\sAs\sSystem\.Windows\.Forms\.ToolStripItemClickedEventArgs\)|sender\sAs\sObject\,\se\sAs\sToolStripItemClickedEventArgs)\)"

        Dim patternToolStripItemEventArgs As String = "\b\w+_(ItemAdded|ItemRemoved)\((ByVal\ssender\sAs\sObject\,\sByVal\se\sAs\sSystem\.Windows\.Forms\.ToolStripItemEventArgs\)|sender\sAs\sObject\,\se\sAs\sSystem\.Windows\.Forms\.ToolStripItemEventArgs\)|sender\sAs\sObject\,\se\sAs\sToolStripItemEventArgs)\)"

        Dim patternToolStripDropDownClosingEventArgs As String = "\b\w+_Closing\((ByVal\ssender\sAs\sObject\,\sByVal\se\sAs\sSystem\.Windows\.Forms\.ToolStripDropDownClosingEventArgs\)|sender\sAs\sObject\,\se\sAs\sSystem\.Windows\.Forms\.ToolStripDropDownClosingEventArgs\)|sender\sAs\sObject\,\se\sAs\sToolStripDropDownClosingEventArgs)\)"

        Dim patternToolStripDropDownClosedEventArgs As String = "\b\w+_Closed\((ByVal\ssender\sAs\sObject\,\sByVal\se\sAs\sSystem\.Windows\.Forms\.ToolStripDropDownClosedEventArgs\)|sender\sAs\sObject\,\se\sAs\sSystem\.Windows\.Forms\.ToolStripDropDownClosedEventArgs\)|sender\sAs\sObject\,\se\sAs\sToolStripDropDownClosedEventArgs)\)"

        Dim patternListChangedEventArgs As String = "\b\w+_ListChanged\((ByVal\ssender\sAs\sObject\,\sByVal\se\sAs\sSystem\.Windows\.Forms\.ListChangedEventArgs\)|sender\sAs\sObject\,\se\sAs\sSystem\.Windows\.Forms\.ListChangedEventArgs\)|sender\sAs\sObject\,\se\sAs\sListChangedEventArgs)\)"

        Dim patternBindingManagerDataErrorEventArgs As String = "\b\w+_DataError\((ByVal\ssender\sAs\sObject\,\sByVal\se\sAs\sSystem\.Windows\.Forms\.BindingManagerDataErrorEventArgs\)|sender\sAs\sObject\,\se\sAs\sSystem\.Windows\.Forms\.BindingManagerDataErrorEventArgs\)|sender\sAs\sObject\,\se\sAs\sBindingManagerDataErrorEventArgs)\)"

        Dim patternAddingNewEventArgs As String = "\b\w+_AddingNew\((ByVal\ssender\sAs\sObject\,\sByVal\se\sAs\sSystem\.Windows\.Forms\.AddingNewEventArgs\)|sender\sAs\sObject\,\se\sAs\sSystem\.Windows\.Forms\.AddingNewEventArgs\)|sender\sAs\sObject\,\se\sAs\sAddingNewEventArgs)\)"

        Dim patternBindingCompleteEventArgs As String = "\b\w+_BindingComplete\((ByVal\ssender\sAs\sObject\,\sByVal\se\sAs\sSystem\.Windows\.Forms\.BindingCompleteEventArgs\)|sender\sAs\sObject\,\se\sAs\sSystem\.Windows\.Forms\.BindingCompleteEventArgs\)|sender\sAs\sObject\,\se\sAs\sBindingCompleteEventArgs)\)"


        'Splitting HeadAches...
        Dim parts() As String
        'Dim parts1() As String
        Dim strMatch2 As String

        'Handles WebBrowserProgressChangedEventArgs fix
        For Each m In Regex.Matches(txtVBNetText, patternWebBrowserProgressChangedEventArgs, RegexOptions.IgnoreCase Or RegexOptions.Multiline)
            strMatch = m.Value
            strMatch2 = strMatch
            strMatch = strMatch.Replace("(", " ")
            strMatch = strMatch.Replace("_", " ")
            strMatch = strMatch.Replace(" ", ",")

            parts = strMatch.Split(",")

            txtVBNetText = Replace(txtVBNetText, strMatch2, parts(0) & "_" & parts(1) & _
                                   "(sender As Object, e As System.Windows.Forms.WebBrowserProgressChangedEventArgs) Handles " & _
                                   parts(0) & "." & parts(1), RegexOptions.IgnoreCase)

            strMatch = String.Empty
        Next

        'Handles WebBrowserNavigatedEventArgs fix
        For Each m In Regex.Matches(txtVBNetText, patternWebBrowserNavigatedEventArgs, RegexOptions.IgnoreCase Or RegexOptions.Multiline)
            strMatch = m.Value
            strMatch2 = strMatch
            strMatch = strMatch.Replace("(", " ")
            strMatch = strMatch.Replace("_", " ")
            strMatch = strMatch.Replace(" ", ",")

            parts = strMatch.Split(",")

            txtVBNetText = Replace(txtVBNetText, strMatch2, parts(0) & "_" & parts(1) & _
                                   "(sender As Object, e As System.Windows.Forms.WebBrowserNavigatedEventArgs) Handles " & _
                                   parts(0) & "." & parts(1), RegexOptions.IgnoreCase)

            strMatch = String.Empty
        Next

        'Handles WebBrowserNavigatingEventArgs fix
        For Each m In Regex.Matches(txtVBNetText, patternWebBrowserNavigatingEventArgs, RegexOptions.IgnoreCase Or RegexOptions.Multiline)
            strMatch = m.Value
            strMatch2 = strMatch
            strMatch = strMatch.Replace("(", " ")
            strMatch = strMatch.Replace("_", " ")
            strMatch = strMatch.Replace(" ", ",")

            parts = strMatch.Split(",")

            txtVBNetText = Replace(txtVBNetText, strMatch2, parts(0) & "_" & parts(1) & _
                                   "(sender As Object, e As System.Windows.Forms.WebBrowserNavigatingEventArgs) Handles " & _
                                   parts(0) & "." & parts(1), RegexOptions.IgnoreCase)

            strMatch = String.Empty
        Next

        'Handles WebBrowserDocumentCompletedEventArgs fix
        For Each m In Regex.Matches(txtVBNetText, patternWebBrowserDocumentCompletedEventArgs, RegexOptions.IgnoreCase Or RegexOptions.Multiline)
            strMatch = m.Value
            strMatch2 = strMatch
            strMatch = strMatch.Replace("(", " ")
            strMatch = strMatch.Replace("_", " ")
            strMatch = strMatch.Replace(" ", ",")

            parts = strMatch.Split(",")

            txtVBNetText = Replace(txtVBNetText, strMatch2, parts(0) & "_" & parts(1) & _
                                   "(sender As Object, e As System.Windows.Forms.WebBrowserDocumentCompletedEventArgs) Handles " & _
                                   parts(0) & "." & parts(1), RegexOptions.IgnoreCase)

            strMatch = String.Empty
        Next

        'Handles TreeNodeMouseClickEventArgs fix
        For Each m In Regex.Matches(txtVBNetText, patternTreeNodeMouseClickEventArgs, RegexOptions.IgnoreCase Or RegexOptions.Multiline)
            strMatch = m.Value
            strMatch2 = strMatch
            strMatch = strMatch.Replace("(", " ")
            strMatch = strMatch.Replace("_", " ")
            strMatch = strMatch.Replace(" ", ",")

            parts = strMatch.Split(",")

            txtVBNetText = Replace(txtVBNetText, strMatch2, parts(0) & "_" & parts(1) & _
                                   "(sender As Object, e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles " & _
                                   parts(0) & "." & parts(1), RegexOptions.IgnoreCase)

            strMatch = String.Empty
        Next

        'Handles TreeNodeMouseClickEventArgs fix
        For Each m In Regex.Matches(txtVBNetText, patternTreeNodeMouseClickEventArgs, RegexOptions.IgnoreCase Or RegexOptions.Multiline)
            strMatch = m.Value
            strMatch2 = strMatch
            strMatch = strMatch.Replace("(", " ")
            strMatch = strMatch.Replace("_", " ")
            strMatch = strMatch.Replace(" ", ",")

            parts = strMatch.Split(",")

            txtVBNetText = Replace(txtVBNetText, strMatch2, parts(0) & "_" & parts(1) & _
                                   "(sender As Object, e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles " & _
                                   parts(0) & "." & parts(1), RegexOptions.IgnoreCase)

            strMatch = String.Empty
        Next

        'Handles DrawTreeNodeEventArgs fix
        For Each m In Regex.Matches(txtVBNetText, patternDrawTreeNodeEventArgs, RegexOptions.IgnoreCase Or RegexOptions.Multiline)
            strMatch = m.Value
            strMatch2 = strMatch
            strMatch = strMatch.Replace("(", " ")
            strMatch = strMatch.Replace("_", " ")
            strMatch = strMatch.Replace(" ", ",")

            parts = strMatch.Split(",")

            txtVBNetText = Replace(txtVBNetText, strMatch2, parts(0) & "_" & parts(1) & _
                                   "(sender As Object, e As System.Windows.Forms.DrawTreeNodeEventArgs) Handles " & _
                                   parts(0) & "." & parts(1), RegexOptions.IgnoreCase)

            strMatch = String.Empty
        Next

        'Handles TreeViewCancelEventArgs fix
        For Each m In Regex.Matches(txtVBNetText, patternTreeViewCancelEventArgs, RegexOptions.IgnoreCase Or RegexOptions.Multiline)
            strMatch = m.Value
            strMatch2 = strMatch
            strMatch = strMatch.Replace("(", " ")
            strMatch = strMatch.Replace("_", " ")
            strMatch = strMatch.Replace(" ", ",")

            parts = strMatch.Split(",")

            txtVBNetText = Replace(txtVBNetText, strMatch2, parts(0) & "_" & parts(1) & _
                                   "(sender As Object, e As System.Windows.Forms.TreeViewCancelEventArgs) Handles " & _
                                   parts(0) & "." & parts(1), RegexOptions.IgnoreCase)

            strMatch = String.Empty
        Next

        'Handles NodeLabelEditEventArgs fix
        For Each m In Regex.Matches(txtVBNetText, patternNodeLabelEditEventArgs, RegexOptions.IgnoreCase Or RegexOptions.Multiline)
            strMatch = m.Value
            strMatch2 = strMatch
            strMatch = strMatch.Replace("(", " ")
            strMatch = strMatch.Replace("_", " ")
            strMatch = strMatch.Replace(" ", ",")

            parts = strMatch.Split(",")

            txtVBNetText = Replace(txtVBNetText, strMatch2, parts(0) & "_" & parts(1) & _
                                   "(sender As Object, e As System.Windows.Forms.NodeLabelEditEventArgs) Handles " & _
                                   parts(0) & "." & parts(1), RegexOptions.IgnoreCase)

            strMatch = String.Empty
        Next

        'Handles TreeViewEventArgs fix
        For Each m In Regex.Matches(txtVBNetText, patternTreeViewEventArgs, RegexOptions.IgnoreCase Or RegexOptions.Multiline)
            strMatch = m.Value
            strMatch2 = strMatch
            strMatch = strMatch.Replace("(", " ")
            strMatch = strMatch.Replace("_", " ")
            strMatch = strMatch.Replace(" ", ",")

            parts = strMatch.Split(",")

            txtVBNetText = Replace(txtVBNetText, strMatch2, parts(0) & "_" & parts(1) & _
                                   "(sender As Object, e As System.Windows.Forms.TreeViewEventArgs) Handles " & _
                                   parts(0) & "." & parts(1), RegexOptions.IgnoreCase)

            strMatch = String.Empty
        Next

        'Handles PopupEventArgs fix
        For Each m In Regex.Matches(txtVBNetText, patternPopupEventArgs, RegexOptions.IgnoreCase Or RegexOptions.Multiline)
            strMatch = m.Value
            strMatch2 = strMatch
            strMatch = strMatch.Replace("(", " ")
            strMatch = strMatch.Replace("_", " ")
            strMatch = strMatch.Replace(" ", ",")

            parts = strMatch.Split(",")

            txtVBNetText = Replace(txtVBNetText, strMatch2, parts(0) & "_" & parts(1) & _
                                   "(sender As Object, e As System.Windows.Forms.PopupEventArgs) Handles " & _
                                   parts(0) & "." & parts(1), RegexOptions.IgnoreCase)

            strMatch = String.Empty
        Next

        'Handles DrawToolTipEventArgs fix
        For Each m In Regex.Matches(txtVBNetText, patternDrawToolTipEventArgs, RegexOptions.IgnoreCase Or RegexOptions.Multiline)
            strMatch = m.Value
            strMatch2 = strMatch
            strMatch = strMatch.Replace("(", " ")
            strMatch = strMatch.Replace("_", " ")
            strMatch = strMatch.Replace(" ", ",")

            parts = strMatch.Split(",")

            txtVBNetText = Replace(txtVBNetText, strMatch2, parts(0) & "_" & parts(1) & _
                                   "(sender As Object, e As System.Windows.Forms.DrawToolTipEventArgs) Handles " & _
                                   parts(0) & "." & parts(1), RegexOptions.IgnoreCase)

            strMatch = String.Empty
        Next

        'Handles TabControlCancelEventArgs fix
        For Each m In Regex.Matches(txtVBNetText, patternTabControlCancelEventArgs, RegexOptions.IgnoreCase Or RegexOptions.Multiline)
            strMatch = m.Value
            strMatch2 = strMatch
            strMatch = strMatch.Replace("(", " ")
            strMatch = strMatch.Replace("_", " ")
            strMatch = strMatch.Replace(" ", ",")

            parts = strMatch.Split(",")

            txtVBNetText = Replace(txtVBNetText, strMatch2, parts(0) & "_" & parts(1) & _
                                   "(sender As Object, e As System.Windows.Forms.TabControlCancelEventArgs) Handles " & _
                                   parts(0) & "." & parts(1), RegexOptions.IgnoreCase)

            strMatch = String.Empty
        Next

        'Handles TabControlEventArgs fix
        For Each m In Regex.Matches(txtVBNetText, patternTabControlEventArgs, RegexOptions.IgnoreCase Or RegexOptions.Multiline)
            strMatch = m.Value
            strMatch2 = strMatch
            strMatch = strMatch.Replace("(", " ")
            strMatch = strMatch.Replace("_", " ")
            strMatch = strMatch.Replace(" ", ",")

            parts = strMatch.Split(",")

            txtVBNetText = Replace(txtVBNetText, strMatch2, parts(0) & "_" & parts(1) & _
                                   "(sender As Object, e As System.Windows.Forms.TabControlEventArgs) Handles " & _
                                   parts(0) & "." & parts(1), RegexOptions.IgnoreCase)

            strMatch = String.Empty
        Next

        'Handles SplitterCancelEventArgs fix
        For Each m In Regex.Matches(txtVBNetText, patternSplitterCancelEventArgs, RegexOptions.IgnoreCase Or RegexOptions.Multiline)
            strMatch = m.Value
            strMatch2 = strMatch
            strMatch = strMatch.Replace("(", " ")
            strMatch = strMatch.Replace("_", " ")
            strMatch = strMatch.Replace(" ", ",")

            parts = strMatch.Split(",")

            txtVBNetText = Replace(txtVBNetText, strMatch2, parts(0) & "_" & parts(1) & _
                                   "(sender As Object, e As System.Windows.Forms.SplitterCancelEventArgs) Handles " & _
                                   parts(0) & "." & parts(1), RegexOptions.IgnoreCase)

            strMatch = String.Empty
        Next

        'Handles SplitterEventArgs fix
        For Each m In Regex.Matches(txtVBNetText, patternSplitterEventArgs, RegexOptions.IgnoreCase Or RegexOptions.Multiline)
            strMatch = m.Value
            strMatch2 = strMatch
            strMatch = strMatch.Replace("(", " ")
            strMatch = strMatch.Replace("_", " ")
            strMatch = strMatch.Replace(" ", ",")

            parts = strMatch.Split(",")

            txtVBNetText = Replace(txtVBNetText, strMatch2, parts(0) & "_" & parts(1) & _
                                   "(sender As Object, e As System.Windows.Forms.SplitterEventArgs) Handles " & _
                                   parts(0) & "." & parts(1), RegexOptions.IgnoreCase)

            strMatch = String.Empty
        Next

        'Handles SerialPinChangedEventArgs fix
        For Each m In Regex.Matches(txtVBNetText, patternSerialPinChangedEventArgs, RegexOptions.IgnoreCase Or RegexOptions.Multiline)
            strMatch = m.Value
            strMatch2 = strMatch
            strMatch = strMatch.Replace("(", " ")
            strMatch = strMatch.Replace("_", " ")
            strMatch = strMatch.Replace(" ", ",")

            parts = strMatch.Split(",")

            txtVBNetText = Replace(txtVBNetText, strMatch2, parts(0) & "_" & parts(1) & _
                                   "(sender As Object, e As System.IO.Ports.SerialPinChangedEventArgs) Handles " & _
                                   parts(0) & "." & parts(1), RegexOptions.IgnoreCase)

            strMatch = String.Empty
        Next

        'Handles SerialErrorReceivedEventArgs fix
        For Each m In Regex.Matches(txtVBNetText, patternSerialErrorReceivedEventArgs, RegexOptions.IgnoreCase Or RegexOptions.Multiline)
            strMatch = m.Value
            strMatch2 = strMatch
            strMatch = strMatch.Replace("(", " ")
            strMatch = strMatch.Replace("_", " ")
            strMatch = strMatch.Replace(" ", ",")

            parts = strMatch.Split(",")

            txtVBNetText = Replace(txtVBNetText, strMatch2, parts(0) & "_" & parts(1) & _
                                   "(sender As Object, e As System.IO.Ports.SerialErrorReceivedEventArgs) Handles " & _
                                   parts(0) & "." & parts(1), RegexOptions.IgnoreCase)

            strMatch = String.Empty
        Next

        'Handles SerialDataReceivedEventArgs fix
        For Each m In Regex.Matches(txtVBNetText, patternSerialDataReceivedEventArgs, RegexOptions.IgnoreCase Or RegexOptions.Multiline)
            strMatch = m.Value
            strMatch2 = strMatch
            strMatch = strMatch.Replace("(", " ")
            strMatch = strMatch.Replace("_", " ")
            strMatch = strMatch.Replace(" ", ",")

            parts = strMatch.Split(",")

            txtVBNetText = Replace(txtVBNetText, strMatch2, parts(0) & "_" & parts(1) & _
                                   "(sender As Object, e As System.IO.Ports.SerialDataReceivedEventArgs) Handles " & _
                                   parts(0) & "." & parts(1), RegexOptions.IgnoreCase)

            strMatch = String.Empty
        Next

        'Handles LinkClickedEventArgs fix
        For Each m In Regex.Matches(txtVBNetText, patternLinkClickedEventArgs, RegexOptions.IgnoreCase Or RegexOptions.Multiline)
            strMatch = m.Value
            strMatch2 = strMatch
            strMatch = strMatch.Replace("(", " ")
            strMatch = strMatch.Replace("_", " ")
            strMatch = strMatch.Replace(" ", ",")

            parts = strMatch.Split(",")

            txtVBNetText = Replace(txtVBNetText, strMatch2, parts(0) & "_" & parts(1) & _
                                   "(sender As Object, e As System.Windows.Forms.LinkClickedEventArgs) Handles " & _
                                   parts(0) & "." & parts(1), RegexOptions.IgnoreCase)

            strMatch = String.Empty
        Next

        'Handles SelectedGridItemChangedEventArgs fix
        For Each m In Regex.Matches(txtVBNetText, patternSelectedGridItemChangedEventArgs, RegexOptions.IgnoreCase Or RegexOptions.Multiline)
            strMatch = m.Value
            strMatch2 = strMatch
            strMatch = strMatch.Replace("(", " ")
            strMatch = strMatch.Replace("_", " ")
            strMatch = strMatch.Replace(" ", ",")

            parts = strMatch.Split(",")

            txtVBNetText = Replace(txtVBNetText, strMatch2, parts(0) & "_" & parts(1) & _
                                   "(sender As Object, e As System.Windows.Forms.SelectedGridItemChangedEventArgs) Handles " & _
                                   parts(0) & "." & parts(1), RegexOptions.IgnoreCase)

            strMatch = String.Empty
        Next

        'Handles PropertyValueChangedEventArgs fix
        For Each m In Regex.Matches(txtVBNetText, patternPropertyValueChangedEventArgs, RegexOptions.IgnoreCase Or RegexOptions.Multiline)
            strMatch = m.Value
            strMatch2 = strMatch
            strMatch = strMatch.Replace("(", " ")
            strMatch = strMatch.Replace("_", " ")
            strMatch = strMatch.Replace(" ", ",")

            parts = strMatch.Split(",")

            txtVBNetText = Replace(txtVBNetText, strMatch2, parts(0) & "_" & parts(1) & _
                                   "(sender As Object, e As System.Windows.Forms.PropertyValueChangedEventArgs) Handles " & _
                                   parts(0) & "." & parts(1), RegexOptions.IgnoreCase)

            strMatch = String.Empty
        Next

        'Handles PropertyTabChangedEventArgs fix
        For Each m In Regex.Matches(txtVBNetText, patternPropertyTabChangedEventArgs, RegexOptions.IgnoreCase Or RegexOptions.Multiline)
            strMatch = m.Value
            strMatch2 = strMatch
            strMatch = strMatch.Replace("(", " ")
            strMatch = strMatch.Replace("_", " ")
            strMatch = strMatch.Replace(" ", ",")

            parts = strMatch.Split(",")

            txtVBNetText = Replace(txtVBNetText, strMatch2, parts(0) & "_" & parts(1) & _
                                   "(sender As Object, e As System.Windows.Forms.PropertyTabChangedEventArgs) Handles " & _
                                   parts(0) & "." & parts(1), RegexOptions.IgnoreCase)

            strMatch = String.Empty
        Next

        'Handles DataReceivedEventArgs fix
        For Each m In Regex.Matches(txtVBNetText, patternDataReceivedEventArgs, RegexOptions.IgnoreCase Or RegexOptions.Multiline)
            strMatch = m.Value
            strMatch2 = strMatch
            strMatch = strMatch.Replace("(", " ")
            strMatch = strMatch.Replace("_", " ")
            strMatch = strMatch.Replace(" ", ",")

            parts = strMatch.Split(",")

            txtVBNetText = Replace(txtVBNetText, strMatch2, parts(0) & "_" & parts(1) & _
                                   "(sender As Object, e As System.Diagnostics.DataReceivedEventArgs) Handles " & _
                                   parts(0) & "." & parts(1), RegexOptions.IgnoreCase)

            strMatch = String.Empty
        Next

        'Handles ProgressChangedEventArgs fix
        For Each m In Regex.Matches(txtVBNetText, patternProgressChangedEventArgs, RegexOptions.IgnoreCase Or RegexOptions.Multiline)
            strMatch = m.Value
            strMatch2 = strMatch
            strMatch = strMatch.Replace("(", " ")
            strMatch = strMatch.Replace("_", " ")
            strMatch = strMatch.Replace(" ", ",")

            parts = strMatch.Split(",")

            txtVBNetText = Replace(txtVBNetText, strMatch2, parts(0) & "_" & parts(1) & _
                                   "(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles " & _
                                   parts(0) & "." & parts(1), RegexOptions.IgnoreCase)

            strMatch = String.Empty
        Next

        'Handles AsyncCompletedEventArgs fix
        For Each m In Regex.Matches(txtVBNetText, patternAsyncCompletedEventArgs, RegexOptions.IgnoreCase Or RegexOptions.Multiline)
            strMatch = m.Value
            strMatch2 = strMatch
            strMatch = strMatch.Replace("(", " ")
            strMatch = strMatch.Replace("_", " ")
            strMatch = strMatch.Replace(" ", ",")

            parts = strMatch.Split(",")

            txtVBNetText = Replace(txtVBNetText, strMatch2, parts(0) & "_" & parts(1) & _
                                   "(sender As Object, e As System.ComponentModel.AsyncCompletedEventArgs) Handles " & _
                                   parts(0) & "." & parts(1), RegexOptions.IgnoreCase)

            strMatch = String.Empty
        Next

        'Handles TypeValidationEventArgs fix
        For Each m In Regex.Matches(txtVBNetText, patternTypeValidationEventArgs, RegexOptions.IgnoreCase Or RegexOptions.Multiline)
            strMatch = m.Value
            strMatch2 = strMatch
            strMatch = strMatch.Replace("(", " ")
            strMatch = strMatch.Replace("_", " ")
            strMatch = strMatch.Replace(" ", ",")

            parts = strMatch.Split(",")

            txtVBNetText = Replace(txtVBNetText, strMatch2, parts(0) & "_" & parts(1) & _
                                   "(sender As Object, e As System.Windows.Forms.TypeValidationEventArgs) Handles " & _
                                   parts(0) & "." & parts(1), RegexOptions.IgnoreCase)

            strMatch = String.Empty
        Next

        'Handles MaskInputRejectedEventArgs fix
        For Each m In Regex.Matches(txtVBNetText, patternMaskInputRejectedEventArgs, RegexOptions.IgnoreCase Or RegexOptions.Multiline)
            strMatch = m.Value
            strMatch2 = strMatch
            strMatch = strMatch.Replace("(", " ")
            strMatch = strMatch.Replace("_", " ")
            strMatch = strMatch.Replace(" ", ",")

            parts = strMatch.Split(",")

            txtVBNetText = Replace(txtVBNetText, strMatch2, parts(0) & "_" & parts(1) & _
                                   "(sender As Object, e As System.Windows.Forms.MaskInputRejectedEventArgs) Handles " & _
                                   parts(0) & "." & parts(1), RegexOptions.IgnoreCase)

            strMatch = String.Empty
        Next

        'Handles LinkLabelLinkClickedEventArgs fix
        For Each m In Regex.Matches(txtVBNetText, patternLinkLabelLinkClickedEventArgs, RegexOptions.IgnoreCase Or RegexOptions.Multiline)
            strMatch = m.Value
            strMatch2 = strMatch
            strMatch = strMatch.Replace("(", " ")
            strMatch = strMatch.Replace("_", " ")
            strMatch = strMatch.Replace(" ", ",")

            parts = strMatch.Split(",")

            txtVBNetText = Replace(txtVBNetText, strMatch2, parts(0) & "_" & parts(1) & _
                                   "(sender As Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles " & _
                                   parts(0) & "." & parts(1), RegexOptions.IgnoreCase)

            strMatch = String.Empty
        Next

        'Handles ToolStripItemClickedEventArgs fix
        For Each m In Regex.Matches(txtVBNetText, patternToolStripItemClickedEventArgs, RegexOptions.IgnoreCase Or RegexOptions.Multiline)
            strMatch = m.Value
            strMatch2 = strMatch
            strMatch = strMatch.Replace("(", " ")
            strMatch = strMatch.Replace("_", " ")
            strMatch = strMatch.Replace(" ", ",")

            parts = strMatch.Split(",")

            txtVBNetText = Replace(txtVBNetText, strMatch2, parts(0) & "_" & parts(1) & _
                                   "(sender As Object, e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles " & _
                                   parts(0) & "." & parts(1), RegexOptions.IgnoreCase)

            strMatch = String.Empty
        Next

        'Handles ToolStripItemEventArgs fix
        For Each m In Regex.Matches(txtVBNetText, patternToolStripItemEventArgs, RegexOptions.IgnoreCase Or RegexOptions.Multiline)
            strMatch = m.Value
            strMatch2 = strMatch
            strMatch = strMatch.Replace("(", " ")
            strMatch = strMatch.Replace("_", " ")
            strMatch = strMatch.Replace(" ", ",")

            parts = strMatch.Split(",")

            txtVBNetText = Replace(txtVBNetText, strMatch2, parts(0) & "_" & parts(1) & _
                                   "(sender As Object, e As System.Windows.Forms.ToolStripItemEventArgs) Handles " & _
                                   parts(0) & "." & parts(1), RegexOptions.IgnoreCase)

            strMatch = String.Empty
        Next

        'Handles ToolStripDropDownClosingEventArgs fix
        For Each m In Regex.Matches(txtVBNetText, patternToolStripDropDownClosingEventArgs, RegexOptions.IgnoreCase Or RegexOptions.Multiline)
            strMatch = m.Value
            strMatch2 = strMatch
            strMatch = strMatch.Replace("(", " ")
            strMatch = strMatch.Replace("_", " ")
            strMatch = strMatch.Replace(" ", ",")

            parts = strMatch.Split(",")

            txtVBNetText = Replace(txtVBNetText, strMatch2, parts(0) & "_" & parts(1) & _
                                   "(sender As Object, e As System.Windows.Forms.ToolStripDropDownClosingEventArgs) Handles " & _
                                   parts(0) & "." & parts(1), RegexOptions.IgnoreCase)

            strMatch = String.Empty
        Next

        'Handles ToolStripDropDownClosedEventArgs fix
        For Each m In Regex.Matches(txtVBNetText, patternToolStripDropDownClosedEventArgs, RegexOptions.IgnoreCase Or RegexOptions.Multiline)
            strMatch = m.Value
            strMatch2 = strMatch
            strMatch = strMatch.Replace("(", " ")
            strMatch = strMatch.Replace("_", " ")
            strMatch = strMatch.Replace(" ", ",")

            parts = strMatch.Split(",")

            txtVBNetText = Replace(txtVBNetText, strMatch2, parts(0) & "_" & parts(1) & _
                                   "(sender As Object, e As System.Windows.Forms.ToolStripDropDownClosedEventArgs) Handles " & _
                                   parts(0) & "." & parts(1), RegexOptions.IgnoreCase)

            strMatch = String.Empty
        Next

        'Handles ListChangedEventArgs fix
        For Each m In Regex.Matches(txtVBNetText, patternListChangedEventArgs, RegexOptions.IgnoreCase Or RegexOptions.Multiline)
            strMatch = m.Value
            strMatch2 = strMatch
            strMatch = strMatch.Replace("(", " ")
            strMatch = strMatch.Replace("_", " ")
            strMatch = strMatch.Replace(" ", ",")

            parts = strMatch.Split(",")

            txtVBNetText = Replace(txtVBNetText, strMatch2, parts(0) & "_" & parts(1) & _
                                   "(sender As Object, e As System.Windows.Forms.ListChangedEventArgs) Handles " & _
                                   parts(0) & "." & parts(1), RegexOptions.IgnoreCase)

            strMatch = String.Empty
        Next

        'Handles BindingManagerDataErrorEventArgs fix
        For Each m In Regex.Matches(txtVBNetText, patternBindingManagerDataErrorEventArgs, RegexOptions.IgnoreCase Or RegexOptions.Multiline)
            strMatch = m.Value
            strMatch2 = strMatch
            strMatch = strMatch.Replace("(", " ")
            strMatch = strMatch.Replace("_", " ")
            strMatch = strMatch.Replace(" ", ",")

            parts = strMatch.Split(",")

            txtVBNetText = Replace(txtVBNetText, strMatch2, parts(0) & "_" & parts(1) & _
                                   "(sender As Object, e As System.Windows.Forms.BindingManagerDataErrorEventArgs) Handles " & _
                                   parts(0) & "." & parts(1), RegexOptions.IgnoreCase)

            strMatch = String.Empty
        Next

        'Handles AddingNewEventArgs fix
        For Each m In Regex.Matches(txtVBNetText, patternAddingNewEventArgs, RegexOptions.IgnoreCase Or RegexOptions.Multiline)
            strMatch = m.Value
            strMatch2 = strMatch
            strMatch = strMatch.Replace("(", " ")
            strMatch = strMatch.Replace("_", " ")
            strMatch = strMatch.Replace(" ", ",")

            parts = strMatch.Split(",")

            txtVBNetText = Replace(txtVBNetText, strMatch2, parts(0) & "_" & parts(1) & _
                                   "(sender As Object, e As System.Windows.Forms.AddingNewEventArgs) Handles " & _
                                   parts(0) & "." & parts(1), RegexOptions.IgnoreCase)

            strMatch = String.Empty
        Next

        'Handles BindingCompleteEventArgs fix
        For Each m In Regex.Matches(txtVBNetText, patternBindingCompleteEventArgs, RegexOptions.IgnoreCase Or RegexOptions.Multiline)
            strMatch = m.Value
            strMatch2 = strMatch
            strMatch = strMatch.Replace("(", " ")
            strMatch = strMatch.Replace("_", " ")
            strMatch = strMatch.Replace(" ", ",")

            parts = strMatch.Split(",")

            txtVBNetText = Replace(txtVBNetText, strMatch2, parts(0) & "_" & parts(1) & _
                                   "(sender As Object, e As System.Windows.Forms.BindingCompleteEventArgs) Handles " & _
                                   parts(0) & "." & parts(1), RegexOptions.IgnoreCase)

            strMatch = String.Empty
        Next

        'Repair the comments
        txtVBNetText = Regex.Replace(txtVBNetText, cmmt1, "", RegexOptions.None)
        txtVBNetText = Regex.Replace(txtVBNetText, cmmt2, "'", RegexOptions.None)
        txtVBNetText = Regex.Replace(txtVBNetText, cmmt3, "#Region " & """", RegexOptions.None)
        txtVBNetText = Regex.Replace(txtVBNetText, cmmt4, "#End Region", RegexOptions.None)

        'Adding new lines for readability.
        txtVBNetText = Regex.Replace(txtVBNetText, "End Sub\b", "End Sub" & vbCrLf & vbCrLf, RegexOptions.Multiline)
        txtVBNetText = Regex.Replace(txtVBNetText, "End Function\b", "End Function" & vbCrLf & vbCrLf, RegexOptions.Multiline)
        Return txtVBNetText
    End Function

#End Region

#Region "C#"

    Public Shared Function FixCS(ByVal txt As String) As String
        Dim txtCSharpText As String = txt
        'Remove the Error statements left by the C# conversion.
        txtCSharpText = Replace(txtCSharpText, "// ERROR: Handles clauses are not supported in C#", "")
        txtCSharpText = Replace(txtCSharpText, "// ERROR: Implements clauses are not supported in C#", "")

        Return txtCSharpText
    End Function

#End Region
    
End Class
