<%@ Page Title="DwollaAPI samples" Language="C#" MasterPageFile="~/MasterPage.master"
	AutoEventWireup="true" %>

<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="Server">
	<p>OAuth allows Dwolla to access your private data with your authorization, but
		without you having to give up your password. </p>
	<p>Select a demo:</p>
	<ul>
        <li><a href="AccountBalance.aspx">Get balance</a></li>
        <li><a href="UserContacts.aspx">Get contacts</a></li>
        <li><a href="Nearby.aspx">Get nearby Dwolla spots</a></li>
        <li><a href="RegisterUser.aspx">Register a user</a></li>
        <li><a href="TransactionsListing.aspx">Get transactions listing</a></li>
        <li><a href="TransactionsDetailsById.aspx">Get transactions by identifier</a></li>
        <li><a href="TransactionsStats.aspx">Get transactions stats</a></li>
        <li><a href="Send.aspx">Send funds to a destination</a></li>
        <li><a href="Request.aspx">Request funds from a source user</a></li>
        <li><a href="AccountInformation.aspx">Get account information</a></li>
        <li><a href="BasicInformation.aspx">Get basic account information</a></li>
	</ul>
</asp:Content>