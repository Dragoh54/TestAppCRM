import { useQuery } from "@tanstack/react-query";
import { getContacts } from "../api/contactsApi";

export const useContacts = (
    page: number,
    pageSize: number
) => {
    return useQuery({
        queryKey: ["contacts", page, pageSize],

        queryFn: () => getContacts(page, pageSize),
    });
};