import {
    Box,
    Button,
    CircularProgress,
    Dialog,
    DialogActions,
    DialogContent,
    DialogTitle,
    Divider,
    TextField,
} from "@mui/material";
import { AddBookDialogProps, CreateBookDto } from "../types/books";
import { useState } from "react";

const initialFormData: Partial<CreateBookDto> = {
    title: '',
    author: '',
    description: '',
    owner: '',
};

export default function AddBookDialog({ open, onClose, onSubmit }: AddBookDialogProps) {
    const [formData, setFormData] = useState<Partial<CreateBookDto>>(initialFormData);
    const [loading, setLoading] = useState(false);

    const handleChange = (field: keyof CreateBookDto, value: string) => {
        setFormData(prev => ({ ...prev, [field]: value }));
    };

    const handleSubmit = async (e: React.FormEvent) => {
        e.preventDefault();
        setLoading(true);
        await onSubmit(formData as CreateBookDto);
        setLoading(false);
        setFormData(initialFormData);
        onClose();
    };

    const handleClose = () => {
        setFormData(initialFormData);
        onClose();
    };

    return (
        <Dialog open={open} onClose={handleClose} fullWidth maxWidth="sm">
            <form onSubmit={handleSubmit}>
                <DialogTitle sx={{ fontWeight: 700, pb: 1 }}>Add New Book</DialogTitle>
                <Divider />
                <DialogContent>
                    <Box sx={{ display: 'flex', flexDirection: 'column', gap: 2, pt: 1 }}>
                        <TextField
                            label="Title"
                            value={formData.title}
                            onChange={(e) => handleChange('title', e.target.value)}
                            fullWidth
                            required
                            autoFocus
                        />
                        <TextField
                            label="Author"
                            value={formData.author}
                            onChange={(e) => handleChange('author', e.target.value)}
                            fullWidth
                        />
                        <TextField
                            label="Owner"
                            value={formData.owner}
                            onChange={(e) => handleChange('owner', e.target.value)}
                            fullWidth
                        />
                    </Box>
                </DialogContent>
                <Divider />
                <DialogActions sx={{ px: 3, py: 2, gap: 1 }}>
                    <Button onClick={handleClose} disabled={loading} color="inherit">
                        Cancel
                    </Button>
                    <Button
                        type="submit"
                        variant="contained"
                        disabled={loading}
                        startIcon={loading ? <CircularProgress size={16} color="inherit" /> : null}
                    >
                        {loading ? 'Adding…' : 'Add Book'}
                    </Button>
                </DialogActions>
            </form>
        </Dialog>
    );
}