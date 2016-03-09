Notes:

	1. Name, ISBN, Author start and end indexes mentioned in the description didn't match with the sample file provided. Sample file has updated to match the description.
	
	2. To run the program:
		a. Copy updated input files A.TXT and B.TXT from AppData folder to C:\InforBooks folder. This location can be changed by making changes to the variable AppDataLocation in App.config		
	
	3. To add new File format:
		a. Copy new input file to C:\InforBooks
		b. Add Name, ISBN, Author start & end index values in App.config.
			eg:
			    <add key="CJ:NameStartIndex" value="1"/>
				<add key="CJ:NameEndIndex" value="20"/>
				<add key="CJ:ISBNStartIndex" value="21"/>
				<add key="CJ:ISBNEndIndex" value="41"/>
				<add key="CJ:AuthorStartIndex" value="42"/>
				<add key="CJ:AuthorEndIndex" value="62"/>
		c. First part of the key, in this case CJ should exactly match with the first line in the input file.