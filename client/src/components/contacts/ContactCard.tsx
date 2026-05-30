import type { Contact } from "../../types/contact";

type Props = {
    contact: Contact;
};

export const ContactCard = ({ contact }: Props) => {
    return (
        <div
            className="
                rounded-2xl
                border
                border-slate-200
                bg-white
                p-5
                shadow-sm
                transition
                hover:shadow-lg
            "
        >
            <h3
                className="
                    text-xl
                    font-bold
                    text-slate-800
                "
            >
                {contact.name}
            </h3>

            <div className="mt-4 space-y-2">
                <p className="text-slate-600">
                    📱 {contact.mobilePhone}
                </p>

                <p className="text-slate-600">
                    💼 {contact.jobTitle}
                </p>

                <p className="text-slate-600">
                    🎂 {new Date(contact.birthDate)
                        .toLocaleDateString()}
                </p>
            </div>

            <div className="mt-5 flex gap-2">
                <button
                    className="
                        rounded-lg
                        bg-blue-600
                        px-4
                        py-2
                        text-white
                        transition
                        hover:bg-blue-700
                    "
                >
                    Edit
                </button>

                <button
                    className="
                        rounded-lg
                        bg-red-600
                        px-4
                        py-2
                        text-white
                        transition
                        hover:bg-red-700
                    "
                >
                    Delete
                </button>
            </div>
        </div>
    );
};