import { ContactCard } from "../components/contacts/ContactCard";
import { useContacts } from "../hooks/useContact";

export const ContactsPage = () => {
    const {
        data,
        isLoading,
        isError,
    } = useContacts(1, 12);

    if (isLoading) {
        return (
            <div className="p-10 text-center">
                Loading...
            </div>
        );
    }

    if (isError) {
        return (
            <div className="p-10 text-center text-red-500">
                Failed to load contacts
            </div>
        );
    }

    return (
        <div
            className="
                mx-auto
                max-w-7xl
                px-6
                py-10
            "
        >
            <div
                className="
                    mb-8
                    flex
                    items-center
                    justify-between
                "
            >
                <h1
                    className="
                        text-4xl
                        font-bold
                    "
                >
                    Contacts
                </h1>

                <button
                    className="
                        rounded-xl
                        bg-emerald-600
                        px-5
                        py-3
                        text-white
                        font-semibold
                        transition
                        hover:bg-emerald-700
                    "
                >
                    + Add Contact
                </button>
            </div>

            <div
                className="
                    grid
                    gap-6
                    md:grid-cols-2
                    lg:grid-cols-3
                "
            >
                {data?.items.map(contact => (
                    <ContactCard
                        key={contact.id}
                        contact={contact}
                    />
                ))}
            </div>
        </div>
    );
};