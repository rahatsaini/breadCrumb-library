import { BookTableProps } from '../types/books';
import { DataGrid, GridColDef, GridRenderCellParams } from '@mui/x-data-grid';
import { Box, Chip, IconButton, Tooltip } from '@mui/material';
import SwapHorizIcon from '@mui/icons-material/SwapHoriz';
import DeleteIcon from '@mui/icons-material/Delete';

export default function BookDataGrid({books, loading, onDelete, onToggleAvailability}: BookTableProps) {
    const columns: GridColDef[] = [{
        field: 'title',
        headerName: 'Title',
        flex: 1,
        minWidth: 180,
    }, {
        field: 'owner',
        headerName: 'Owner',
        flex: 1,
        minWidth: 150,
    }, 
     {
        field: 'borrowedBy',
        headerName: 'Borrowed By',
        flex: 1,
        minWidth: 150,
    }, 
    {
        field: 'borrowedUTC',
        headerName: 'Borrowed at',
        flex: 1,
        minWidth: 150,
    }, 
    {
        field: 'isAvailable',
        headerName: 'Status',
        width: 110,
        align: 'center',
        headerAlign: 'center',
        renderCell: (params: GridRenderCellParams) => (
            <Chip
                label={params.row.isAvailable ? 'Available' : 'Borrowed'}
                color={params.row.isAvailable ? 'success' : 'warning'}
                size="small"
                sx={{ fontWeight: 600, minWidth: 80 }}
            />
        ),
    }, {
        field: 'actions',
        headerName: 'Actions',
        width: 110,
        sortable: false,
        filterable: false,
        align: 'center',
        headerAlign: 'center',
        renderCell: (params: GridRenderCellParams) => (
            <Box sx={{ display: 'flex', gap: 0.5 }}>
                <Tooltip title={params.row.isAvailable ? 'Borrow' : 'Return'}>
                    <IconButton
                        color={params.row.isAvailable ? 'primary' : 'secondary'}
                        size="small"
                        onClick={() => onToggleAvailability && onToggleAvailability(params.row.id)}
                    >
                        <SwapHorizIcon fontSize="small" />
                    </IconButton>
                </Tooltip>
                <Tooltip title="Delete">
                    <IconButton
                        color="error"
                        size="small"
                        onClick={() => onDelete && onDelete(params.row.id)}
                    >
                        <DeleteIcon fontSize="small" />
                    </IconButton>
                </Tooltip>
            </Box>
        ),
    }]

    return (
        <DataGrid
            columns={columns}
            loading={loading}
            rows={books}
            autoHeight
            hideFooter
            disableRowSelectionOnClick
       
        />
    );
}

