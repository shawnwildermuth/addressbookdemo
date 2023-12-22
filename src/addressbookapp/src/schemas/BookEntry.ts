import { object, string, nullable } from "zod";

export const entrySchema = object({
  firstName: string().min(1),
  lastName: string().min(1),
  email: string().email().nullable(),
  // cellPhone: string().nullable(),
  // homePhone: string().nullable(),
  // workPhone: string().nullable(),
});

//export type entrySchemaType 