using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace zmuist
{
	class Program
	{
		static void Main(string[] args)
		{


			string[] CommandFix(string Commm, int Linenum)
			{
				string Comm = Commm + " ";

				char[] Cchar = Comm.ToCharArray();

				string Varr = "";
				string Arra = "";
				string Arrb = "";
				string Vala = "";
				string Valb = "";

				string Ignore = "";

				int Mmode = 0;
				int Mstart = -1;
				int Mend = -1;
				int Mbad = -1;

				for (int n = 0; n < Comm.Length; n = n + 1)
				{
					if (Mbad == -1)
					{
						char Ssss = Cchar[n];
						if (Mmode == 0)
						{
							if (Char.IsLetter(Ssss))
							{
								Mstart = n;
								Mend = -1;
								Mmode = 1;
							}
							else if (Ssss.ToString() != " ")
							{
								if (Ssss.ToString() == "#")
								{
									Mbad = n;
								}
								else
								{
									Mbad = n;
									string Rrr = "";
									Console.WriteLine("");
									Console.WriteLine("");
									Console.WriteLine("Error on Line " + Linenum.ToString() + ":");
									Console.WriteLine("Position " + n.ToString());
									Console.WriteLine("");
									Console.WriteLine(Comm);
									while (Rrr.Length < n) { Rrr = Rrr + " "; }
									Console.WriteLine(Rrr + "^");
									Console.WriteLine("");
									Console.WriteLine("Unexpected symbol: " + Ssss.ToString());
									Console.WriteLine("");
								}
							}
						}
						else if (Mmode == 1)
						{
							if (!Char.IsLetter(Ssss))
							{
								if ((Ssss.ToString() == " ") | (Ssss.ToString() == "["))
								{
									Mend = n;

									Varr = Comm.Substring(Mstart, Mend - Mstart);

									Mstart = -1;
									Mend = -1;

									if (Ssss.ToString() == " ") { Mmode = 2; }
									if (Ssss.ToString() == "[") { Mmode = 3; }
								}
								else
								{
									Mbad = n;
									string Rrr = "";
									Console.WriteLine("");
									Console.WriteLine("");
									Console.WriteLine("Error on Line " + Linenum.ToString() + ":");
									Console.WriteLine("Position " + n.ToString());
									Console.WriteLine("");
									Console.WriteLine(Comm);
									while (Rrr.Length < n) { Rrr = Rrr + " "; }
									Console.WriteLine(Rrr + "^");
									Console.WriteLine("");
									Console.WriteLine("Unexpected symbol: " + Ssss.ToString());
									Console.WriteLine("");
								}
							}
						}
						else if (Mmode == 2)
						{
							if (Ssss.ToString() != " ")
							{
								if (Ssss.ToString() == "[")
								{
									Mmode = 3;
								}
								else
								{
									Mbad = n;
									string Rrr = "";
									Console.WriteLine("");
									Console.WriteLine("");
									Console.WriteLine("Error on Line " + Linenum.ToString() + ":");
									Console.WriteLine("Position " + n.ToString());
									Console.WriteLine("");
									Console.WriteLine(Comm);
									while (Rrr.Length < n) { Rrr = Rrr + " "; }
									Console.WriteLine(Rrr + "^");
									Console.WriteLine("");
									Console.WriteLine("Unexpected symbol: " + Ssss.ToString());
									Console.WriteLine("");
								}
							}
						}
						else if (Mmode == 3)
						{
							if (Ssss.ToString() != " ")
							{
								if (Char.IsNumber(Ssss))
								{
									Mmode = 5;
									Mstart = n;
								}
								else
								{
									Mbad = n;
									string Rrr = "";
									Console.WriteLine("");
									Console.WriteLine("");
									Console.WriteLine("Error on Line " + Linenum.ToString() + ":");
									Console.WriteLine("Position " + n.ToString());
									Console.WriteLine("");
									Console.WriteLine(Comm);
									while (Rrr.Length < n) { Rrr = Rrr + " "; }
									Console.WriteLine(Rrr + "^");
									Console.WriteLine("");
									Console.WriteLine("Unexpected symbol: " + Ssss.ToString());
									Console.WriteLine("");
								}
							}
							else
							{
								Mmode = 4;
							}
						}
						else if (Mmode == 4)
						{
							if (Ssss.ToString() != " ")
							{
								if (Char.IsNumber(Ssss))
								{
									Mmode = 5;
									Mstart = n;
								}
								else
								{
									Mbad = n;
									string Rrr = "";
									Console.WriteLine("");
									Console.WriteLine("");
									Console.WriteLine("Error on Line " + Linenum.ToString() + ":");
									Console.WriteLine("Position " + n.ToString());
									Console.WriteLine("");
									Console.WriteLine(Comm);
									while (Rrr.Length < n) { Rrr = Rrr + " "; }
									Console.WriteLine(Rrr + "^");
									Console.WriteLine("");
									Console.WriteLine("Unexpected symbol: " + Ssss.ToString());
									Console.WriteLine("");
								}
							}
						}
						else if (Mmode == 5)
						{
							if (!Char.IsNumber(Ssss))
							{
								if ((Ssss.ToString() == " ") | (Ssss.ToString() == ",") | (Ssss.ToString() == "]"))
								{
									Mend = n;

									Arra = Comm.Substring(Mstart, Mend - Mstart);

									Mstart = -1;
									Mend = -1;

									if (Ssss.ToString() == " ") { Mmode = 6; }
									if (Ssss.ToString() == ",") { Mmode = 7; }
									if (Ssss.ToString() == "]") { Mmode = 11; }

								}
								else
								{
									Mbad = n;
									string Rrr = "";
									Console.WriteLine("");
									Console.WriteLine("");
									Console.WriteLine("Error on Line " + Linenum.ToString() + ":");
									Console.WriteLine("Position " + n.ToString());
									Console.WriteLine("");
									Console.WriteLine(Comm);
									while (Rrr.Length < n) { Rrr = Rrr + " "; }
									Console.WriteLine(Rrr + "^");
									Console.WriteLine("");
									Console.WriteLine("Unexpected symbol: " + Ssss.ToString());
									Console.WriteLine("");
								}
							}
						}
						else if (Mmode == 6)
						{
							if (Ssss.ToString() != " ")
							{
								if ((Ssss.ToString() == ",") | (Ssss.ToString() == "]"))
								{
									if (Ssss.ToString() == ",") { Mmode = 7; }
									if (Ssss.ToString() == "]") { Mmode = 11; }
								}
								else
								{
									Mbad = n;
									string Rrr = "";
									Console.WriteLine("");
									Console.WriteLine("");
									Console.WriteLine("Error on Line " + Linenum.ToString() + ":");
									Console.WriteLine("Position " + n.ToString());
									Console.WriteLine("");
									Console.WriteLine(Comm);
									while (Rrr.Length < n) { Rrr = Rrr + " "; }
									Console.WriteLine(Rrr + "^");
									Console.WriteLine("");
									Console.WriteLine("Unexpected symbol: " + Ssss.ToString());
									Console.WriteLine("");
								}
							}
						}
						else if (Mmode == 7)
						{
							if (Ssss.ToString() != " ")
							{
								if (Char.IsNumber(Ssss))
								{
									Mmode = 9;
									Mstart = n;
								}
								else
								{
									Mbad = n;
									string Rrr = "";
									Console.WriteLine("");
									Console.WriteLine("");
									Console.WriteLine("Error on Line " + Linenum.ToString() + ":");
									Console.WriteLine("Position " + n.ToString());
									Console.WriteLine("");
									Console.WriteLine(Comm);
									while (Rrr.Length < n) { Rrr = Rrr + " "; }
									Console.WriteLine(Rrr + "^");
									Console.WriteLine("");
									Console.WriteLine("Unexpected symbol: " + Ssss.ToString());
									Console.WriteLine("");
								}
							}
							else
							{
								Mmode = 8;
							}
						}
						else if (Mmode == 8)
						{
							if (Ssss.ToString() != " ")
							{
								if (Char.IsNumber(Ssss))
								{
									Mmode = 9;
									Mstart = n;
								}
								else
								{
									Mbad = n;
									string Rrr = "";
									Console.WriteLine("");
									Console.WriteLine("");
									Console.WriteLine("Error on Line " + Linenum.ToString() + ":");
									Console.WriteLine("Position " + n.ToString());
									Console.WriteLine("");
									Console.WriteLine(Comm);
									while (Rrr.Length < n) { Rrr = Rrr + " "; }
									Console.WriteLine(Rrr + "^");
									Console.WriteLine("");
									Console.WriteLine("Unexpected symbol: " + Ssss.ToString());
									Console.WriteLine("");
								}
							}
						}
						else if (Mmode == 9)
						{
							if (!Char.IsNumber(Ssss))
							{
								if ((Ssss.ToString() == " ") | (Ssss.ToString() == "]"))
								{
									Mend = n;

									Arrb = Comm.Substring(Mstart, Mend - Mstart);

									Mstart = -1;
									Mend = -1;

									if (Ssss.ToString() == " ") { Mmode = 10; }
									if (Ssss.ToString() == "]") { Mmode = 11; }

								}
								else
								{
									Mbad = n;
									string Rrr = "";
									Console.WriteLine("");
									Console.WriteLine("");
									Console.WriteLine("Error on Line " + Linenum.ToString() + ":");
									Console.WriteLine("Position " + n.ToString());
									Console.WriteLine("");
									Console.WriteLine(Comm);
									while (Rrr.Length < n) { Rrr = Rrr + " "; }
									Console.WriteLine(Rrr + "^");
									Console.WriteLine("");
									Console.WriteLine("Unexpected symbol: " + Ssss.ToString());
									Console.WriteLine("");
								}
							}
						}
						else if (Mmode == 10)
						{
							if (Ssss.ToString() != " ")
							{
								if (Ssss.ToString() == "]")
								{
									Mmode = 11;
								}
								else
								{
									Mbad = n;
									string Rrr = "";
									Console.WriteLine("");
									Console.WriteLine("");
									Console.WriteLine("Error on Line " + Linenum.ToString() + ":");
									Console.WriteLine("Position " + n.ToString());
									Console.WriteLine("");
									Console.WriteLine(Comm);
									while (Rrr.Length < n) { Rrr = Rrr + " "; }
									Console.WriteLine(Rrr + "^");
									Console.WriteLine("");
									Console.WriteLine("Unexpected symbol: " + Ssss.ToString());
									Console.WriteLine("");
								}
							}
						}
						else if (Mmode == 11)
						{
							if (Ssss.ToString() != " ")
							{
								if (Ssss.ToString() == "=")
								{
									Mmode = 13;
								}
								else
								{
									Mbad = n;
									string Rrr = "";
									Console.WriteLine("");
									Console.WriteLine("");
									Console.WriteLine("Error on Line " + Linenum.ToString() + ":");
									Console.WriteLine("Position " + n.ToString());
									Console.WriteLine("");
									Console.WriteLine(Comm);
									while (Rrr.Length < n) { Rrr = Rrr + " "; }
									Console.WriteLine(Rrr + "^");
									Console.WriteLine("");
									Console.WriteLine("Unexpected symbol: " + Ssss.ToString());
									Console.WriteLine("");
								}
							}
							else
							{
								Mmode = 12;
							}
						}
						else if (Mmode == 12)
						{
							if (Ssss.ToString() != " ")
							{
								if (Ssss.ToString() == "=")
								{
									Mmode = 13;
								}
								else
								{
									Mbad = n;
									string Rrr = "";
									Console.WriteLine("");
									Console.WriteLine("");
									Console.WriteLine("Error on Line " + Linenum.ToString() + ":");
									Console.WriteLine("Position " + n.ToString());
									Console.WriteLine("");
									Console.WriteLine(Comm);
									while (Rrr.Length < n) { Rrr = Rrr + " "; }
									Console.WriteLine(Rrr + "^");
									Console.WriteLine("");
									Console.WriteLine("Unexpected symbol: " + Ssss.ToString());
									Console.WriteLine("");
								}
							}
						}
						else if (Mmode == 13)
						{
							if (Ssss.ToString() != " ")
							{
								if (Char.IsNumber(Ssss))
								{
									Mmode = 15;
									Mstart = n;
								}
								else
								{
									Mbad = n;
									string Rrr = "";
									Console.WriteLine("");
									Console.WriteLine("");
									Console.WriteLine("Error on Line " + Linenum.ToString() + ":");
									Console.WriteLine("Position " + n.ToString());
									Console.WriteLine("");
									Console.WriteLine(Comm);
									while (Rrr.Length < n) { Rrr = Rrr + " "; }
									Console.WriteLine(Rrr + "^");
									Console.WriteLine("");
									Console.WriteLine("Unexpected symbol: " + Ssss.ToString());
									Console.WriteLine("");
								}
							}
							else
							{
								Mmode = 14;
							}
						}
						else if (Mmode == 14)
						{
							if (Ssss.ToString() != " ")
							{
								if (Char.IsNumber(Ssss))
								{
									Mmode = 15;
									Mstart = n;
								}
								else
								{
									Mbad = n;
									string Rrr = "";
									Console.WriteLine("");
									Console.WriteLine("");
									Console.WriteLine("Error on Line " + Linenum.ToString() + ":");
									Console.WriteLine("Position " + n.ToString());
									Console.WriteLine("");
									Console.WriteLine(Comm);
									while (Rrr.Length < n) { Rrr = Rrr + " "; }
									Console.WriteLine(Rrr + "^");
									Console.WriteLine("");
									Console.WriteLine("Unexpected symbol: " + Ssss.ToString());
									Console.WriteLine("");
								}
							}
						}
						else if (Mmode == 15)
						{
							if (!Char.IsNumber(Ssss))
							{
								if ((Ssss.ToString() == " ") | (Ssss.ToString() == ","))
								{
									Mend = n;

									Vala = Comm.Substring(Mstart, Mend - Mstart);

									Mstart = -1;
									Mend = -1;

									if (Ssss.ToString() == " ") { Mmode = 16; }
									if (Ssss.ToString() == ",") { Mmode = 17; }

								}
								else
								{
									Mbad = n;
									string Rrr = "";
									Console.WriteLine("");
									Console.WriteLine("");
									Console.WriteLine("Error on Line " + Linenum.ToString() + ":");
									Console.WriteLine("Position " + n.ToString());
									Console.WriteLine("");
									Console.WriteLine(Comm);
									while (Rrr.Length < n) { Rrr = Rrr + " "; }
									Console.WriteLine(Rrr + "^");
									Console.WriteLine("");
									Console.WriteLine("Unexpected symbol: " + Ssss.ToString());
									Console.WriteLine("");
								}
							}
						}
						else if (Mmode == 16)
						{
							if (Ssss.ToString() != " ")
							{
								if (Ssss.ToString() == ",")
								{
									Mmode = 17;
								}
								else
								{
									Mbad = n;
									string Rrr = "";
									Console.WriteLine("");
									Console.WriteLine("");
									Console.WriteLine("Error on Line " + Linenum.ToString() + ":");
									Console.WriteLine("Position " + n.ToString());
									Console.WriteLine("");
									Console.WriteLine(Comm);
									while (Rrr.Length < n) { Rrr = Rrr + " "; }
									Console.WriteLine(Rrr + "^");
									Console.WriteLine("");
									Console.WriteLine("Unexpected symbol: " + Ssss.ToString());
									Console.WriteLine("");
								}
							}
						}
						else if (Mmode == 17)
						{
							if (Ssss.ToString() != " ")
							{
								if (Char.IsNumber(Ssss))
								{
									Mmode = 19;
									Mstart = n;
								}
								else
								{
									Mbad = n;
									string Rrr = "";
									Console.WriteLine("");
									Console.WriteLine("");
									Console.WriteLine("Error on Line " + Linenum.ToString() + ":");
									Console.WriteLine("Position " + n.ToString());
									Console.WriteLine("");
									Console.WriteLine(Comm);
									while (Rrr.Length < n) { Rrr = Rrr + " "; }
									Console.WriteLine(Rrr + "^");
									Console.WriteLine("");
									Console.WriteLine("Unexpected symbol: " + Ssss.ToString());
									Console.WriteLine("");
								}
							}
							else
							{
								Mmode = 18;
							}
						}
						else if (Mmode == 18)
						{
							if (Ssss.ToString() != " ")
							{
								if (Char.IsNumber(Ssss))
								{
									Mmode = 19;
									Mstart = n;
								}
								else
								{
									Mbad = n;
									string Rrr = "";
									Console.WriteLine("");
									Console.WriteLine("");
									Console.WriteLine("Error on Line " + Linenum.ToString() + ":");
									Console.WriteLine("Position " + n.ToString());
									Console.WriteLine("");
									Console.WriteLine(Comm);
									while (Rrr.Length < n) { Rrr = Rrr + " "; }
									Console.WriteLine(Rrr + "^");
									Console.WriteLine("");
									Console.WriteLine("Unexpected symbol: " + Ssss.ToString());
									Console.WriteLine("");
								}
							}
						}
						else if (Mmode == 19)
						{
							if (!Char.IsNumber(Ssss))
							{
								if (Ssss.ToString() == " ")
								{
									Mend = n;

									Valb = Comm.Substring(Mstart, Mend - Mstart);

									Mstart = -1;
									Mend = -1;

									Mmode = 20;

								}
								else
								{
									Mbad = n;
									string Rrr = "";
									Console.WriteLine("");
									Console.WriteLine("");
									Console.WriteLine("Error on Line " + Linenum.ToString() + ":");
									Console.WriteLine("Position " + n.ToString());
									Console.WriteLine("");
									Console.WriteLine(Comm);
									while (Rrr.Length < n) { Rrr = Rrr + " "; }
									Console.WriteLine(Rrr + "^");
									Console.WriteLine("");
									Console.WriteLine("Unexpected symbol: " + Ssss.ToString());
									Console.WriteLine("");
								}
							}
						}
						else if (Mmode == 20)
						{
							if (Ssss.ToString() != " ")
							{
								Mbad = n;
								string Rrr = "";
								Console.WriteLine("");
								Console.WriteLine("");
								Console.WriteLine("Error on Line " + Linenum.ToString() + ":");
								Console.WriteLine("Position " + n.ToString());
								Console.WriteLine("");
								Console.WriteLine(Comm);
								while (Rrr.Length < n) { Rrr = Rrr + " "; }
								Console.WriteLine(Rrr + "^");
								Console.WriteLine("");
								Console.WriteLine("Unexpected symbol: " + Ssss.ToString());
								Console.WriteLine("");
							}
						}
					}
				}

				if ((Mmode != 0) & (Mmode != 16) & (Mmode != 20) & (Mbad == -1))
				{
					Console.WriteLine("");
					Console.WriteLine("");
					Console.WriteLine("Error on Line " + Linenum.ToString() + ":");
					Console.WriteLine("");
					Console.WriteLine(Comm);
					Console.WriteLine("");
					Console.WriteLine("Incomplete command");
					Console.WriteLine("");
					Mbad = 1;
				}

				if ((Mmode != 0) & (Varr != "DScenID") & (Varr != "DButtonID") & (Varr != "DObjTextID") & (Varr != "DTutTextID") & (Varr != "DDriftID") & (Mbad == -1))
				{
					Console.WriteLine("");
					Console.WriteLine("");
					Console.WriteLine("Error on Line " + Linenum.ToString() + ":");
					Console.WriteLine("");
					Console.WriteLine(Comm);
					Console.WriteLine("");
					Console.WriteLine("Unknown Variable: " + Varr);
					Console.WriteLine("");
					Mbad = 1;
				}

				if ((Arrb != "") & (Mbad == -1))
				{
					int aaa = Int32.Parse(Arra);
					int bbb = Int32.Parse(Arrb);
					if (aaa >= bbb)
					{
						Console.WriteLine("");
						Console.WriteLine("");
						Console.WriteLine("Error on Line " + Linenum.ToString() + ":");
						Console.WriteLine("");
						Console.WriteLine(Comm);
						Console.WriteLine("");
						Console.WriteLine("Beginning array index is greater than ending array index");
						Console.WriteLine("");
						Mbad = 1;
					}
				}

				if ((Arrb == "") & (Valb != "") & (Mbad == -1))
				{
					Console.WriteLine("");
					Console.WriteLine("");
					Console.WriteLine("Error on Line " + Linenum.ToString() + ":");
					Console.WriteLine("");
					Console.WriteLine(Comm);
					Console.WriteLine("");
					Console.WriteLine("Ending array index is not defined");
					Console.WriteLine("");
					Mbad = 1;
				}

				if (Mbad != -1)
				{
					Ignore = "Yes";
				}

				string [] Dsdsd = { Varr, Arra, Arrb, Vala, Valb, Ignore};
				return Dsdsd;
			}


			if (args.Length != null)
			{
				if (args.Length == 0)
				{
					Console.WriteLine("ZAC's MUIS Tool");
					Console.WriteLine("");
					Console.WriteLine("Created by: TheZACAtac");
					Console.WriteLine("Version: Beta");
					Console.WriteLine("");
					Console.WriteLine("Commands:");
					Console.WriteLine("zmuist decode SOURCE [DESTINATION]");
					Console.WriteLine("  -Decodes SOURCE (a .bin file) into a text-based version and");
					Console.WriteLine("   saves the file as a .txt. If DESTINATION is not defined, ");
					Console.WriteLine("   then destination file is SOURCE.txt");
					Console.WriteLine("zmuist encode SOURCE [DESTINATION]");
					Console.WriteLine("  -Encodes SOURCE (a .txt file) into a .bin. If DESTINATION ");
					Console.WriteLine("   is not defined, then destination file is SOURCE.bin");
				}
				if ((args.Length >= 1) & (args.Length <= 3))
				{
					if (args[0].ToLower() == "decode")
					{
						if (args.Length == 1)
						{
							Console.WriteLine("Error: No file defined");
						}
						if (args.Length >= 2)
						{
							string Fsource = args[1];
							string Fdest = "";
							if (args.Length == 3)
							{
								Fdest = args[2];
							}
							if (args.Length == 2)
							{
								Fdest = Fsource + ".txt";
							}
							Console.WriteLine("Decode \"" + Fsource + "\" --> \"" + Fdest + "\"");
							if (!File.Exists(Fsource))
							{
								Console.WriteLine("Error: Source file does not exist");
							}
							if (File.Exists(Fdest))
							{
								Console.WriteLine("Error: Destination file already exists");
							}
							if (File.Exists(Fsource) & !File.Exists(Fdest))
							{
								using (BinaryReader b = new BinaryReader(
									File.Open(Fsource, FileMode.Open)))
								{

									int length = (int)b.BaseStream.Length;

									if (length == 640)
									{
										using (System.IO.StreamWriter file = new System.IO.StreamWriter(@Fdest, true))
										{
											file.WriteLine("#This is what a MUIS text file looks like.");
											file.WriteLine("#Aceptable commands");
											file.WriteLine("# VALUETYPE[LEVEL]=VALUE");
											file.WriteLine("# VALUETYPE[LEVELSTART,LEVELEND]=VALUESTART[,INCREMENT]");
											file.WriteLine("#     -Increment defaults to 1");
											file.WriteLine("#---------------------------------------------------------");

											for (int n = 0; n < 64; n = n + 1)
											{
												int Aa = b.ReadByte();
												int Ab = b.ReadByte();
												int Ba = b.ReadByte();
												int Bb = b.ReadByte();
												int Ca = b.ReadByte();
												int Cb = b.ReadByte();
												int Da = b.ReadByte();
												int Db = b.ReadByte();
												int Ea = b.ReadByte();
												int Eb = b.ReadByte();
												int Aaaa = Aa * 16 + Ab;
												int Bbbb = Da * 16 + Bb;
												int Cccc = Ca * 16 + Cb;
												int Dddd = Da * 16 + Db;
												int Eeee = Ea * 16 + Eb;
												file.WriteLine("DScenID[" + n.ToString() + "]=" + Aaaa.ToString());
												file.WriteLine("DButtonID[" + n.ToString() + "]=" + Bbbb.ToString());
												file.WriteLine("DObjTextID[" + n.ToString() + "]=" + Cccc.ToString());
												file.WriteLine("DTutTextID[" + n.ToString() + "]=" + Dddd.ToString());
												file.WriteLine("DDriftID[" + n.ToString() + "]=" + Eeee.ToString());
											}
										}
									}
								}
							}
						}
					}

					if (args[0].ToLower() == "encode")
					{
						if (args.Length == 1)
						{
							Console.WriteLine("Error: No file defined");
						}
						if (args.Length >= 2)
						{
							string Fsource = args[1];
                            string Fdest = "";
                            if (args.Length == 3)
                            {
                                Fdest = args[2];
                            }
                            if (args.Length == 2)
                            {
                                Fdest = Fsource + ".bin";
                            }
                            Console.WriteLine("Encode \"" + Fsource + "\" --> \"" + Fdest + "\"");
                            if (!File.Exists(Fsource))
                            {
                                Console.WriteLine("Error: Source file does not exist");
                            }
                            if (File.Exists(Fdest))
                            {
                                Console.WriteLine("Error: Destination file already exists");
                            }

							if (File.Exists(Fsource) & !File.Exists(Fdest))
							{
								byte[] Savebyte = new byte[640];
								for (int n=0; n<Savebyte.Length; n=n+1)
								{
									Savebyte[n] = 0;
								}

								string[] lines = System.IO.File.ReadAllLines(@Fsource);

								for (int n = 0; n < lines.Length; n = n + 1)
								{
									string lll = lines[n];
									string[] newline = CommandFix(lll, n);
									if (newline[5]=="")
									{
										int Invarr = 0;
										int Inarra = 0;
										int Inarrb = -1;
										int Invala = 0;
										int Invalb = 1;

										if (newline[0]== "DScenID") { Invarr = 0; }
										if (newline[0] == "DButtonID") { Invarr = 1; }
										if (newline[0] == "DObjTextID") { Invarr = 2; }
										if (newline[0] == "DTutTextID") { Invarr = 3; }
										if (newline[0] == "DDriftID") { Invarr = 4; }

										if (newline[1] != "") { Inarra = Int32.Parse(newline[1]); }
										if (newline[2] != "") { Inarrb = Int32.Parse(newline[2]); }
										if (newline[3] != "") { Invala = Int32.Parse(newline[3]); }
										if (newline[4] != "") { Invalb = Int32.Parse(newline[4]); }
										Console.WriteLine("");
										if (Inarrb == -1)
										{
											byte[] bytes = BitConverter.GetBytes(Invala);
											Savebyte[Inarra * 10 + Invarr * 2] = bytes[1];
											Savebyte[Inarra * 10 + Invarr * 2 + 1] = bytes[0];
										}
										else
										{
											for (int nn = Inarra; nn <= Inarrb; nn += 1)
											{
												byte[] bytes = BitConverter.GetBytes(Invala+(nn-Inarra)* Invalb);
												Savebyte[nn * 10 + Invarr * 2] = bytes[1];
												Savebyte[nn * 10 + Invarr * 2 + 1] = bytes[0];
											}
										}
									}
								}

								File.WriteAllBytes(Fdest, Savebyte);
							}
						}
					}
				}
				if (args.Length > 0)
				{
					if (args[0].ToLower() == "dump")
					{
						if (args.Length == 1)
						{
							Console.WriteLine("Error: No file defined");
						}
						if (args.Length == 2)
						{/*
                            string Fsource = args[1];
                            float Entrya = 0.0F;
                            float Entryb = 0.0F;
                            float Entryc = 0.0F;
                            float Entryd = 0.0F;
                            float Entrye = 0.0F;
                            Console.WriteLine("Dump \"" + Fsource + "\"");
                            if (File.Exists(Fsource))
                            {
                                using (BinaryReader b = new BinaryReader(
                                    File.Open(Fsource, FileMode.Open)))
                                {

                                    int length = (int)b.BaseStream.Length;

                                    if (length == 20)
                                    {
                                        int Aa = b.ReadByte();
                                        int Ab = b.ReadByte();
                                        int Ac = b.ReadByte();
                                        int Ad = b.ReadByte();
                                        int Ba = b.ReadByte();
                                        int Bb = b.ReadByte();
                                        int Bc = b.ReadByte();
                                        int Bd = b.ReadByte();
                                        int Ca = b.ReadByte();
                                        int Cb = b.ReadByte();
                                        int Cc = b.ReadByte();
                                        int Cd = b.ReadByte();
                                        int Da = b.ReadByte();
                                        int Db = b.ReadByte();
                                        int Dc = b.ReadByte();
                                        int Dd = b.ReadByte();
                                        int Ea = b.ReadByte();
                                        int Eb = b.ReadByte();
                                        int Ec = b.ReadByte();
                                        int Ed = b.ReadByte();

                                        byte[] Floater = new byte[] { (byte)Aa, (byte)Ab, (byte)Ac, (byte)Ad };
                                        var Floaters = Floater.Reverse().ToArray();
                                        Entrya = BitConverter.ToSingle(Floaters, 0);
                                        Floater = new byte[] { (byte)Ba, (byte)Bb, (byte)Bc, (byte)Bd };
                                        Floaters = Floater.Reverse().ToArray();
                                        Entryb = BitConverter.ToSingle(Floaters, 0);
                                        Floater = new byte[] { (byte)Ca, (byte)Cb, (byte)Cc, (byte)Cd };
                                        Floaters = Floater.Reverse().ToArray();
                                        Entryc = BitConverter.ToSingle(Floaters, 0);
                                        Floater = new byte[] { (byte)Da, (byte)Db, (byte)Dc, (byte)Dd };
                                        Floaters = Floater.Reverse().ToArray();
                                        Entryd = BitConverter.ToSingle(Floaters, 0);
                                        Floater = new byte[] { (byte)Ea, (byte)Eb, (byte)Ec, (byte)Ed };
                                        Floaters = Floater.Reverse().ToArray();
                                        Entrye = BitConverter.ToSingle(Floaters, 0);
                                        Console.WriteLine("");
                                        Console.WriteLine("Variable:        Value:");
                                        Console.WriteLine("----------------------------------");
                                        Console.WriteLine("Speed            " + Entrya.ToString());
                                        Console.WriteLine("Unknown1         " + Entryb.ToString());
                                        Console.WriteLine("Unknown2         " + Entryc.ToString());
                                        Console.WriteLine("Unknown3         " + Entryd.ToString());
                                        Console.WriteLine("Unknown4         " + Entrye.ToString());
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("Error: File does not exist");
                            }
                        */
						}
						if (args.Length == 3)
						{
							Console.WriteLine("SYNTAX ERROR");
						}
					}
				}
			}
			if (args.Length >= 4)
			{
				Console.WriteLine("SYNTAX ERROR");
			}
		}
	}
}
