// src/types/book.ts

export interface Book {
  id: number
  title: string
  description?: string
  author?: string
  isAvailable: boolean
  owner?: string
  borrowedBy?: string
  borrowedAtUTC?: string
  createdAtUTC: string
}

export interface PagedResult {
  data: Book[]
  totalCount: number
  totalPages: number
  currentPage: number
  pageSize: number
}

export interface CreateBookDto {
  title: string
  author?: string
  owner?: string
  description?: string,
}

export interface SearchBarProps {
    value: string
    onchange: (value: string) => void
}

export interface BookTableProps {
    books: Book[],
    loading?: boolean,
    error?: string | null,
    page?: number,
    pageSize?: number,
    totalPages?: number,
    totalCount?: number,
    onToggle?: (id: number) => void,
    onDelete?: (id: number) => void,
    onPageChange?: (page: number) => void,
    onPageSizeChange?: (size: number) => void,
    onToggleAvailability?: (id: number) => Promise<void>,
}

export interface TablePaginationProps {
    page: number,
    pageSize: number,
    totalCount: number,
    onPageChange?: (page: number) => void,
    onPageSizeChange?: (size: number) => void,
}

export interface AddBookDialogProps {
    open: boolean,
    onClose: () => void,
    onSubmit: (book: CreateBookDto) => Promise<void>
}