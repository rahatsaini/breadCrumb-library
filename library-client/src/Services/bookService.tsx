import axios from 'axios';
import {  CreateBookDto } from '../types/books';

const api = axios.create({
    baseURL: 'https://localhost:7064/api',
    headers: {
        'Content-Type': 'application/json',
    },
});

export const getBooks = async (search?: string, isAvailable?: boolean, page: number = 1, pageSize: number = 10) => {
    const params: any = { page, pageSize };
    if (search) params.search = search;
    if (isAvailable !== undefined) params.isAvailable = isAvailable;

    const response = await api.get('/books', { params });
    return response.data;
};

export const getBookById = async (id: number) => {
    const response = await api.get(`/books/${id}`);
    return response.data;
}

export const createBooks = async (book: CreateBookDto) => {
    const response = await api.post('/books', book);
    return response.data;
}

export const deleteBooks = async (id: number) => {
    await api.delete(`/books/${id}`);
}

export const updateBooks = async (id: number, book: Partial<CreateBookDto>) => {
    const response = await api.put(`/books/${id}`, book);
    return response.data;
}

export const toggle = async (id: number) => {
    const response = await api.patch(`/books/${id}`);
    return response.data;
}
