import './App.css'
import { useBooks } from './hooks/useBooks';
import { Box, Button, createTheme, ThemeProvider } from '@mui/material';
import BookDataGrid from './components/BookTable';
import SearchBar from './components/SearchBar';
import AppTablePagination from './components/TablePagination';
import AddIcon from '@mui/icons-material/Add';
import { useState } from 'react';
import AddBookDialog from './components/AddBookDialog';

const theme = createTheme({
  palette: {
    primary: {
      main: '#1976d2',
    },
    secondary: {
      main: '#dc004e',
    },
  },
});

function App() {
  const books = useBooks();
  const [addDialogOpen, setAddDialogOpen] = useState(false);

  const handleDialogClose = () => {
    setAddDialogOpen(false);
  };

  return (
    <ThemeProvider theme={theme}>
      <Box sx={{minWidth: '50vw', minHeight: '100vh', bgcolor: 'background.default', p: 4 }}>
        <Box sx={{ maxWidth: 1200, mx: 'auto' }}>
          <Box sx={{ mb: 3 }}>
            <Box component="h1" sx={{ m: 0, fontSize: '1.75rem', fontWeight: 700, color: 'text.primary' }}>
              BreadCrumb Library
            </Box>
            <Box component="p" sx={{ m: 0, mt: 0.5, color: 'text.secondary', fontSize: '0.875rem' }}>
              Manage and browse the book collection
            </Box>
          </Box>

          <Box sx={{ display: 'flex', alignItems: 'center', justifyContent: 'space-between', gap: 2, mb: 2 }}>
            <SearchBar value={books.search} onchange={books.setSearch} />
            <Box sx={{ display: 'flex', alignItems: 'center', gap: 2 }}>
              <AppTablePagination
                page={books.page}
                pageSize={books.pageSize}
                totalCount={books.totalCount}
                onPageChange={books.onPageChange}
                onPageSizeChange={books.setPageSize}
              />
              <Button variant="contained" startIcon={<AddIcon />} onClick={() => setAddDialogOpen(true)}>
                Add Book
              </Button>
            </Box>
          </Box>

          <BookDataGrid
            books={books.books}
            loading={books.loading}
            page={books.page}
            pageSize={books.pageSize}
            totalCount={books.totalCount}
            onPageChange={books.setPage}
            onPageSizeChange={books.setPageSize}
            totalPages={books.totalPages}
            onDelete={books.deleteBook}
            onToggleAvailability={books.toggleAvailabilty}
          />
        </Box>
      </Box>
      <AddBookDialog open={addDialogOpen} onClose={handleDialogClose} onSubmit={books.createBook} />
    </ThemeProvider>
  )
}

export default App
