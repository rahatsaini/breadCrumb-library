import { TablePagination } from "@mui/material";
import { TablePaginationProps } from "../types/books";

export default function AppTablePagination({onPageChange, onPageSizeChange, page, pageSize, totalCount}: TablePaginationProps) {

    return (
          <TablePagination
                component="div"
                count={totalCount || 0}
                page={page ? page - 1 : 0}
                rowsPerPage={pageSize || 10}
                rowsPerPageOptions={[5, 10, 25]}
                onPageChange={(_, newPage) => onPageChange ? onPageChange(newPage + 1) : undefined}
                onRowsPerPageChange={(e) => onPageSizeChange ? onPageSizeChange(parseInt(e.target.value)) : undefined}
        />
    );
}