import { api } from "./axios";
import type { Contact } from "../types/contact";
import type { PaginatedResponse } from "../types/paginatedResponse";

export const getContacts = async (
    page = 1,
    pageSize = 10
): Promise<PaginatedResponse<Contact>> => {
    const response = await api.get("/contacts", {
        params: {
            page,
            pageSize,
        },
    });

    return response.data;
};