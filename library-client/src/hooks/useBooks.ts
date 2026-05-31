import { useCallback, useEffect, useState } from "react";
import { Book, CreateBookDto } from "../types/books";
import {
  createBooks,
  deleteBooks,
  getBooks,
  toggle,
} from "../Services/bookService";

interface UseBooksState {
  books: Book[];
  loading: boolean;
  error: string | null;
  page: number;
  pageSize: number;
  totalPages: number;
  totalCount: number;
  search: string;
}

interface UserBooksReturn extends UseBooksState {
  setPage: (page: number) => void;
  setPageSize: (size: number) => void;
  refresh: () => void;
  setSearch: (value: string) => void;
  createBook: (book: CreateBookDto) => Promise<void>;
  deleteBook: (id: number) => Promise<void>;
  onPageChange: (page: number) => void;
  toggleAvailabilty: (id: number) => Promise<void>;
}

export function useBooks(): UserBooksReturn {
  const [state, setState] = useState<UseBooksState>({
    books: [],
    loading: false,
    error: null,
    page: 1,
    pageSize: 10,
    totalPages: 0,
    totalCount: 0,
    search: "",
  });

  const fetchBooks = useCallback(async () => {
    setState((prev) => ({ ...prev, loading: true, error: null }));
    try {
      const result = await getBooks(
        state.search,
        undefined,
        state.page,
        state.pageSize,
      );
      setState((prev) => ({
        ...prev,
        books: result.data,
        totalCount: result.totalCount,
        totalPages: result.totalPages,
        loading: false,
      }));
    } catch (error) {
      setState((prev) => ({
        ...prev,
        loading: false,
        error: error instanceof Error ? error.message : "Unknown error",
      }));
    }
  }, [state.search, state.page, state.pageSize]);

  useEffect(() => {
    fetchBooks();
  }, [fetchBooks]);

  const setPage = (page: number) => setState((prev) => ({ ...prev, page }));

  const setPageSize = (size: number) =>
    setState((prev) => ({ ...prev, pageSize: size }));

  const setSearch = (value: string) =>
    {
        setState((prev) => ({ ...prev,  search: value }));
        
    }

  const refresh = async () => await fetchBooks();

  const createBook = async (book: CreateBookDto) => {
    setState((prev) => ({ ...prev, loading: true, error: null }));
    try {
      await createBooks(book);
      await fetchBooks();
    } catch (error) {
      setState((prev) => ({
        ...prev,
        loading: false,
        error: error instanceof Error ? error.message : "Unknown error",
      }));
    }
  };

  const toggleAvailabilty = async (id: number) => {
    setState((prev) => ({ ...prev, loading: true, error: null }));
    try {
      await toggle(id);
      await fetchBooks();
    } catch (error) {
      setState((prev) => ({
        ...prev,
        loading: false,
        error: error instanceof Error ? error.message : "Unknown error",
      }));
    }
  };

  const deleteBook = async (id: number) => {
    setState((prev) => ({ ...prev, loading: true, error: null }));
    try {
      await deleteBooks(id);
      await fetchBooks();
    } catch (error) {
      setState((prev) => ({
        ...prev,
        loading: false,
        error: error instanceof Error ? error.message : "Unknown error",
      }));
    }
  };

  const onPageChange = (page: number) => setPage(page);
  
  return {
    ...state,
    setPage,
    setPageSize,
    setSearch,
    createBook,
    deleteBook,
    toggleAvailabilty,
    refresh,
    onPageChange,
  };
}
