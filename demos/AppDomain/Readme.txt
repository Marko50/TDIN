First - Is the primary assembly to create a CLR machine.
        It runs on the default Application Domain.
		Creates a second domain, loads and runs the Second assembly on it
		using a single thread to the two domains and inside a single
		operating system process.
		
FirstThr - Creates a second thread to create the second Application Domain.
           The two domains run independently.
		   An Application Domain starts running always on the thread that has created it.