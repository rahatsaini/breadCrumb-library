import { useEffect, useState } from "react";
import { SearchBarProps } from "../types/books";
import { TextField } from "@mui/material";

export default function SearchBar({ value, onchange }: SearchBarProps) {
    const [localValue, setLocalValue] = useState(value);

    useEffect(() => {
        setLocalValue(value);
    }, [value]);

    useEffect(() => {
        onchange(localValue);
    }, [localValue, value, onchange]);



    return (
        <TextField
            label="Search"
            placeholder="Search by titler"
            value={localValue}
            onChange={(e) => setLocalValue(e.target.value)}
        />
    );
}